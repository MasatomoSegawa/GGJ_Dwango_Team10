using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームのロジックを管理するクラス.
/// </summary>
public class GameLogic : MonoBehaviour {

	// タイマーのスクリプト.
	private Timer GameTimer;

	// クエスト予告のスクリプト.
	private Quest quest;

	void Start(){

		// Timer取得.
		GameTimer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer>();

		// Quest取得.
		quest = GameObject.FindGameObjectWithTag ("Quest").GetComponent<Quest> ();

		#region イベント登録.

		GameTimer.TimeEndEvent += E_TimeOver;

		#endregion
	}


	#region イベント
	/// <summary>
	/// プレイヤーが死んだ時に呼び出される.
	/// </summary>
	void E_PlayerDeath(){

	}

	/// <summary>
	/// タイムオーバーした時に呼び出される.
	/// </summary>
	void E_TimeOver(){
		Debug.Log ("Time Over!");
	}
	#endregion

}