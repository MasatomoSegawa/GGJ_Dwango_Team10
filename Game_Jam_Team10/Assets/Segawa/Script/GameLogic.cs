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

		#region コンポーネント取得.
		// Timer取得.
		GameTimer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer>();

		// Quest取得.
		quest = GameObject.FindGameObjectWithTag ("Quest").GetComponent<Quest> ();
		#endregion

		#region イベント登録.
		GameTimer.TimeEndEvent += E_TimeOver;
		#endregion


	}

	#region ゲーム進行処理
	/// <summary>
	/// ゲームオーバーの処理.
	/// </summary>
	void GameOver(){

	}

	/// <summary>
	/// ゲームクリアーの処理.
	/// </summary>
	void GameClear(){

	}
	#endregion

	#region イベント
	/// <summary>
	/// プレイヤーが死んだ時に呼び出される.
	/// </summary>
	void E_PlayerDeath(){
		Debug.Log ("Death!");
	}

	/// <summary>
	/// タイムオーバーした時に呼び出される.
	/// </summary>
	void E_TimeOver(){
		Debug.Log ("Time Over!");
	}
	#endregion

}