using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	protected float base_speed = 200f;
	protected float max_speed = 1;
	protected Rigidbody rb;
	protected bool jumping = false;
	protected float attack_interval = 1f; // 次に攻撃できるまでの時間
	protected float attack_wait = 0;
	protected bool flipRight = true; //右を向いているか？
	public int max_health = 1;
	public int health = 0; 
	protected float damage_dur = 1f; // ダメージを受けた時の無敵時間
	protected float damage_wait = 0;
	public bool isFreeze = false; // 操作不可
	private float jump_force = 450f;
	protected float fixed_rate = 1f;

	// プレイヤーの死
	public delegate void Die();
	public virtual event Die die;

	// Use this for initialization
	protected virtual void Awake () {
	 rb = GetComponent<Rigidbody>();
	 health = max_health;
	}
	
	// Update is called once per frame
	protected virtual void  Update () {

	 if(attack_wait > 0){
	  attack_wait -= Time.deltaTime;
	 }

		if(damage_wait > 0){
			damage_wait -= Time.deltaTime;
	 }

	 // tmp
	 Vector3 scl = this.transform.localScale;
	 Vector3 newScl = new Vector3 ( (flipRight ? 1f : -1f), 1f, 1f);
	 this.transform.localScale = newScl; 

	}

	public virtual void Jump(){
 	 if(jumping){
 	  return;
 	 }
	 Debug.Log("Jump");

	 // play se
	 SoundManager.Instance.PlaySE(0);

	 rb.AddForce(Vector2.up * jump_force * fixed_rate);
 	 jumping = true;
 	
	}

	public virtual void Attack(){
		if(attack_wait > 0){
 	  return;
 	 }

 	 ExecuteAttack();
 	 attack_wait = attack_interval;


	 // play se
	 SoundManager.Instance.PlaySE(1);
	}

	public virtual void ExecuteAttack(){
		Debug.Log("Attack");

	}

	public void Accel(float dir){
	if(health <= 0 || isFreeze){
	return;
	}

	 rb.AddForce(Vector2.right * dir * base_speed);
	 float velocityY = rb.velocity.y;
	 if(rb.velocity.x > max_speed * fixed_rate){
			rb.velocity = new Vector2(max_speed * fixed_rate, velocityY);
	  flipRight = true;
		}else if(rb.velocity.x < -max_speed * fixed_rate){
			rb.velocity = new Vector2(-max_speed * fixed_rate, velocityY);
	 	flipRight = false;
	 }
	 
	}

	public virtual void ApplyDamage(int val){
	 health -= val;
	 if( health < 0 ){
	 health = 0;
	 }

	 if(health <= 0){
	  ChangeStateToDie();
	 }

	 damage_wait = damage_dur;

	 // animation

	}

	protected virtual void ChangeStateToDie(){
	 if(die != null){
		die();
	 }
	}

 protected virtual void OnCollisionEnter(Collision col){
 }

	protected virtual void OnTriggerEnter(Collider col){
 }
}
