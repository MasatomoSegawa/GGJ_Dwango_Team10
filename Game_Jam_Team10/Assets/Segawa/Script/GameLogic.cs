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

	// Pleyrのスクリプト.
	private Player player;

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

		// Player取得.
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		if(player == null)
			print("dame");
		#endregion

		#region イベント登録.

		// Timerのイベント登録.
		GameTimer.TimeEndEvent += E_TimeOver;

		// プレイヤーが死んだ時のイベント登録.
		player.die += GameOver;
		#endregion

		StartCoroutine (GameStart_CutScene());

	}

	#region ゲーム進行処理

	/// <summary>
	/// ゲーム開始時の処理.
	/// </summary>
	/// <returns>The start.</returns>
	IEnumerator GameStart_CutScene(){

		// プレイヤーを操作不可能にする.
		player.isFreeze = true;

		#region スタート開始のカウントダウン処理.
		for(int countDownNumber = 3; countDownNumber > 0; countDownNumber--){
			countDownEffect.StartCountDown(countDownNumber.ToString(), countDownDuration);
			yield return new WaitForSeconds (countDownDuration);
		}

		countDownEffect.StartCountDown("Go!", countDownDuration);
		#endregion

		// プレイヤーを操作可能にする.
		player.isFreeze = false;


	}

	/// <summary>
	/// ゲームオーバーの処理.
	/// </summary>
	void GameOver(){
		Debug.Log ("PlayerDie!");
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