using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public delegate void timeEnd ();
	public timeEnd TimeEndEvent;

	// 時間表示用のUI
	private Text textGUI;

	// 現在の時間
	private float _currentTime;
	public float currentTime{
		get{
			return _currentTime;
		}
	}

	[Header("初期時間")]
	public float initTime = 120.0f;

	[Header("タイマーの処理を止める.")]
	private bool isStop;

	void Start(){
		this.textGUI = transform.GetComponentInChildren<Text> ();

		_currentTime = initTime;
	}

	void Update(){

		if (isStop == false) {
			Tick ();
			UpdateUI ();
		}

	}

	void Tick(){

		_currentTime -= Time.deltaTime;
		_currentTime = Mathf.Clamp (_currentTime, 0.0f, initTime);
		if (_currentTime <= 0.0f) {
			TimeEnd ();
		}

	}

	/// <summary>
	/// タイマーを止める.
	/// </summary>
	public void StopTimer(){
		isStop = true;
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

		textGUI.text = "Time:" + _currentTime.ToString ("F");

	}

}