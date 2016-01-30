using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public delegate void timeEnd ();
	public timeEnd TimeEndEvent;

	// 時間表示用のUI
	private Text textGUI;

	// 現在の時間
	private int _currentTime = 24;
	public int currentTime{
		get{
			return _currentTime;
		}
	}

	// 内部時間.
	private float innerTime;

	[Header("タイマーの処理を止める.")]
	public bool isStop;

	[Header("1時間経つ秒数")]
	public float EveryHourTime;

	void Start(){
		this.textGUI = transform.GetComponentInChildren<Text> ();
		isStop = true;
	}

	void Update(){

		if (isStop == false) {
			Tick ();
			UpdateUI ();
		}

	}

	void Tick(){

		innerTime += Time.deltaTime;
		if (innerTime >= EveryHourTime) {
			if (_currentTime == 24) {
				_currentTime = 0;
			} else {
				_currentTime += 1;
			}

			innerTime = 0.0f;

			if (_currentTime == 8) {
				TimeEnd ();
			}
		}

	}

	/// <summary>
	/// タイマーを止める.
	/// </summary>
	public void StopTimer(){
		isStop = true;
	}

	/// <summary>
	/// タイマーをスタートさせる.
	/// </summary>
	public void StartTimer(){
		isStop = false;
	}

	void TimeEnd(){

		isStop = true;

		if (TimeEndEvent != null) {
			TimeEndEvent ();
		}
	}

	/// <summary>
	/// UIをアップデートする.
	/// </summary>
	void UpdateUI(){

		textGUI.text = _currentTime.ToString () + "時";

	}

}