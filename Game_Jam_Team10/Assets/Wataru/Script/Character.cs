using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	protected float base_speed = 200f;
	protected float max_speed = 1;
	protected Rigidbody rb;
	protected bool jumping = false;
	protected float attack_interval = 1f;
	protected float attack_wait = 0;
	protected bool flipRight = true;
	public int max_health = 3;
	public int health;
	protected bool isDead = false;
	protected float damage_dur = 1f;
	protected float damage_wait = 0;


	// Use this for initialization
	protected virtual void Awake () {
	 rb = GetComponent<Rigidbody>();
	 health = max_health;
	}
	
	// Update is called once per frame
	void Update () {

	 if(attack_wait > 0){
	  attack_wait -= Time.deltaTime;
	 }

		if(damage_wait > 0){
			damage_wait -= Time.deltaTime;
	 }

//	 Debug.Log(rb.velocity);

	 // tmp
	 Vector3 scl = this.transform.localScale;
	 Vector3 newScl = new Vector3 (flipRight ? 1f : -1f, 1f, 1f);
	 this.transform.localScale = newScl; 

	}

	public virtual void Jump(){
 	 if(jumping){
 	  return;
 	 }
		Debug.Log("Jump");
 rb.AddForce(Vector2.up * 300f);
 	 jumping = true;
 	
	}

	public  void Attack(){
		if(attack_wait > 0){
 	  return;
 	 }

 	 ExecuteAttack();
 	 attack_wait = attack_interval;
 	
	}

	public virtual void ExecuteAttack(){
		Debug.Log("Attack");

	}

	public void Accel(float dir){
	 rb.AddForce(Vector2.right * dir * base_speed);
	 float velocityY = rb.velocity.y;
	 if(rb.velocity.x > max_speed){
	  rb.velocity = new Vector2(max_speed, velocityY);
	  flipRight = true;
	 }else if(rb.velocity.x < -max_speed){
	 	rb.velocity = new Vector2(-max_speed, velocityY);
	 	flipRight = false;
	 }
	 
	}

	public void ApplyDamage(int val){
	 health -= val;
	 if( health < 0 ){
	 health = 0;
	 }

	 if(health == 0){
	  isDead = true;
	 }

	 damage_wait = damage_dur;

	 // animation

	}

 protected virtual void OnCollisionEnter(Collision col){
 }

}
