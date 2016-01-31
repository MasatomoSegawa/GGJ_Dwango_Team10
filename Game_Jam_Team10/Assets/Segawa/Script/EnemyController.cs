using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Animator animator;

	public GameObject target;
	public bool dead = false;

	void Start(){

		animator = GetComponent<Animator> ();

		target = GameObject.FindGameObjectWithTag ("Player");

	}

	void Update(){
	if(dead){
	 return;
	}

		// プレイヤーとの距離を取得する.
		float distance = Vector3.Distance (transform.position, target.transform.position);

		// メカニムに距離を送信.
		animator.SetFloat("PlayerDistance", distance);

	}

	public void Die(){
	 dead = true;
	 this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.gray;
	 Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
	 rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

	}
		
}