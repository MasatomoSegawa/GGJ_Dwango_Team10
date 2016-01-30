using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Enemyの生成、削除を管理するクラス.
/// </summary>
public class EnemyFactory : Singleton<EnemyFactory> {

	[Header("生成される敵キャラ")]
	public GameObject enemy;

	[Header("プレイヤーポジションからの生成の距離")]
	public float offsetDistance;

	[Header("敵キャラの生成される間隔(秒)")]
	public float generateDurationSeconds;

	[SerializeField]
	private List<GameObject> enemyList;

	private Player player;

	// 生成されたenemyの数.
	private int _numberOfEnemy;
	public int numberOfEnemy{
		get{
			return _numberOfEnemy;
		}
	}
		
	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		enemyList = new List<GameObject> ();
	}

	public void StartGenerateEnemy(){

		StartCoroutine (GenerateEnemyLoop ());

	}

	IEnumerator GenerateEnemyLoop(){

		while (true) {

			Vector3 pos = RandomNearlyPlayerPosition ();

			GameObject enemy = GenerateEnemy (pos);

			if (enemy == null) {
				_numberOfEnemy += 1;
				enemyList.Add (enemy);
			}

			yield return new WaitForSeconds (generateDurationSeconds);

		}

	}

	/// <summary>
	/// Playerの近くのポジションを返す.
	/// </summary>
	/// <returns>The nearly player position.</returns>
	private Vector3 RandomNearlyPlayerPosition(){

		Vector2 randomPos2 = Random.insideUnitCircle;

		print (randomPos2);

		return (new Vector3(randomPos2.x, randomPos2.y, 0.0f)) * offsetDistance + player.transform.position;

	}

	/// <summary>
	/// Enemyを生成する.
	/// </summary>
	/// <returns>The enemy.</returns>
	private GameObject GenerateEnemy(Vector3 position){

		GameObject obj = Instantiate (enemy, position, Quaternion.identity)as GameObject;

		return obj;
	}

}
