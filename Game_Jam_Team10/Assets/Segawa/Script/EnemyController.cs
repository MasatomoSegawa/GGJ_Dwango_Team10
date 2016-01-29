using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Animator animator;

	public GameObject target;

	void Start(){

		animator = GetComponent<Animator> ();

		target = GameObject.FindGameObjectWithTag ("Player");

	}

	void Update(){

		// プレイヤーとの距離を取得する.
		float distance = Vector3.Distance (transform.position, target.transform.position);

		// メカニムに距離を送信.
		animator.SetFloat("PlayerDistance", distance);

	}
		
}