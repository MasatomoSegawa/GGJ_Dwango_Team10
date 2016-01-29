using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームのロジックを管理するクラス.
/// </summary>
public class GameLogic : MonoBehaviour {

	private Timer GameTimer;

	void Start(){

		// Timer取得.
		GameTimer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer>();

		#region イベント登録.

		GameTimer.TimeEndEvent += E_TimeOver;

		#endregion
	}

	void E_TimeOver(){
		Debug.Log ("Time Over!");
	}

}