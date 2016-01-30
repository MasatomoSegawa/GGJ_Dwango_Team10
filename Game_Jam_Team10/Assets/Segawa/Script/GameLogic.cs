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

	// EnemyFactoryのスクリプト.
	private EnemyFactory enemyFactory;

	[Header("ゲームがスタートされる時の演出のスクリプト")]
	public CountDownEffect countDownEffect;

	[Header("カウントダウンの処理時間")]
	public float countDownDuration;

	[Header("ゲームオーバー時の演出のスクリプト")]
	public GameOverEffect gameOverEffect;

	[Header("ゲームオーバ演出の処理時間")]
	public float gameOverDuration;

	void Start(){

		#region コンポーネント取得.
		// Timer取得.
		GameTimer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer>();

		// Quest取得.
		quest = GameObject.FindGameObjectWithTag ("Quest").GetComponent<Quest> ();

		// Player取得.
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

		enemyFactory = EnemyFactory.Instance;
		#endregion

		#region イベント登録.

		// Timerのイベント登録.
		GameTimer.TimeEndEvent += E_TimeOver;

		// プレイヤーが死んだ時のイベント登録.
		player.die += GameOver;

		// ゲームクリアー時のイベント登録.
		quest.EndQuestEvent += GameClear;
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

		GameTimer.StartTimer ();

		SoundManager.Instance.PlayBGM (0);

		enemyFactory.StartGenerateEnemy ();

	}

	/// <summary>
	/// ゲーム終了時の処理.
	/// </summary>
	/// <returns>The over_ cut scene.</returns>
	IEnumerator GameOver_CutScene(){

		SoundManager.Instance.FadeOutBGM (0);

		// プレイヤーを操作可能にする.
		player.isFreeze = false;

		gameOverEffect.SetEffect (gameOverDuration);

		yield return new WaitForSeconds (gameOverDuration);

	}

	/// <summary>
	/// ゲームオーバーの処理.
	/// </summary>
	void GameOver(){
		Debug.Log ("PlayerDie!");
		StartCoroutine (GameOver_CutScene ());
	}

	/// <summary>
	/// ゲームクリアーの処理.
	/// </summary>
	void GameClear(){
		Debug.Log ("Clear!");
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

	/// <summary>
	/// リトライボタンが押された時に呼び出される.
	/// </summary>
	public void OnRetryButton(){
		FadeManager.Instance.LoadLevel ("Main", 1.0f);
	}

	/// <summary>
	/// タイトルボタンが押された時に呼び出される.
	/// </summary>
	public void OnTitleButton(){
		FadeManager.Instance.LoadLevel ("Title", 1.0f);
	}
	#endregion



}