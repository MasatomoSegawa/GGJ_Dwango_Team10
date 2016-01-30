using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// ゲームのロジックを管理するクラス.
/// </summary>
public class GameLogic : MonoBehaviour {

	// タイマーのスクリプト.
	private Timer GameTimer;

	// クエスト予告のスクリプト.
	private Quest quest;

	[Header("ゲームがスタートされる時の演出のスクリプト")]
	public CountDownEffect countDownEffect;

	[Header("カウントダウンの処理時間")]
	public float countDownDuration;

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

		StartCoroutine (GameStart_CutScene());

	}

	#region ゲーム進行処理

	/// <summary>
	/// ゲーム開始時の処理.
	/// </summary>
	/// <returns>The start.</returns>
	IEnumerator GameStart_CutScene(){
	
	
		#region スタート開始のカウントダウン処理.
		for(int countDownNumber = 3; countDownNumber > 0; countDownNumber--){
			countDownEffect.StartCountDown(countDownNumber.ToString(), countDownDuration);
			yield return new WaitForSeconds (countDownDuration);
		}

		countDownEffect.StartCountDown("Go!", countDownDuration);
		#endregion

	}

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