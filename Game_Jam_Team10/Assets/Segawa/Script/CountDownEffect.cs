using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownEffect : MonoBehaviour {

	private CanvasGroup canvasGroup;
	private Text CountDownText;
	private float startTime;
	private float timeDuration;
	private Color startColor;
	private bool isPlay;

	void Start(){

		CountDownText = GetComponent<Text> ();

		startColor = CountDownText.color;
		CountDownText.color = Color.clear;
	}

	public void StartCountDown(string str,float time){

		// Text初期化.
		CountDownText.text = str;

		// タイムスタンプ整理.
		startTime = Time.timeSinceLevelLoad;
		timeDuration = time;

		// プロパティ初期化.
		CountDownText.color = startColor;
		gameObject.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

		// スケールアニメーション開始.
		iTween.ScaleTo (CountDownText.gameObject, new Vector3(2.0f,2.0f,1.0f), time);

		isPlay = true;

	}

	void Update(){

		if (isPlay == false) {
			return;
		}

		float diff = Time.timeSinceLevelLoad - startTime;
		if (diff >= timeDuration) {
			isPlay = false;
			// プロパティ初期化.
			CountDownText.color = startColor;
			gameObject.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			iTween.Stop ();
		}

		float rate = diff / timeDuration;

		CountDownText.color = Color.Lerp (startColor, Color.clear, rate);

	}


}
