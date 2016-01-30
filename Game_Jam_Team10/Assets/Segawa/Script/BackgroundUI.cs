using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundUI : MonoBehaviour {

	private List<SpriteRenderer> spriteList;

	// タイムオーバーまでの時間.
	private float gameEndTimeDurtion;

	// 一枚の絵を切り替える秒数.
	private float backgroundChangeDuration;

	// リアル時間.
	private float currentTime;

	private Timer timer;

	private SpriteRenderer currentTarget;
	private int index = 1;

	// Use this for initialization
	void Start () {

		spriteList = new List<SpriteRenderer> (transform.GetComponentsInChildren<SpriteRenderer>());

		timer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer> ();

		// ゲーム内時間をリアル時間に変換.
		gameEndTimeDurtion = timer.EveryHourTime * 8;

		// 一枚の絵を切り替える秒数を計算.
		backgroundChangeDuration = gameEndTimeDurtion / spriteList.Count;

		currentTarget = spriteList [index];

		StartCoroutine (ChangeBackgroundLoop ());

		Debug.Log (backgroundChangeDuration);
	}

	IEnumerator ChangeBackgroundLoop(){

		// 1枚目.
		yield return new WaitForSeconds (backgroundChangeDuration);
	
		while (index < spriteList.Count) {
		
			iTween.ValueTo (gameObject, 
				iTween.Hash ("from", 0, "to", 1.0f, "time", backgroundChangeDuration, "onupdate", "ValueChange"));

			yield return new WaitForSeconds (backgroundChangeDuration);

			if (index >= spriteList.Count) {
				StopCoroutine (ChangeBackgroundLoop ());
			}
			index += 1;
			currentTarget = spriteList [index];
		}

	}
		
	void ValueChange(float value){
		Color color = currentTarget.color;
		color.a = value;
		currentTarget.color = color;
	}

}