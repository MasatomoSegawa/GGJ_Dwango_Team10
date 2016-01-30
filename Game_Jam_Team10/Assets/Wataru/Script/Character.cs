using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private float base_speed = 200f;
	private float max_speed = 1;
	private Rigidbody rb;
	private bool jumping = false;

	// Use this for initialization
	void Awake () {
	 rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Jump(){
 	Debug.Log("Jump");
 	if(jumping){
 	  return;
 	}
 	 rb.AddForce(Vector2.up * 300f);
 	 jumping = true;
 	
	}

	public void Accel(float dir){
	 Debug.Log(dir);
	 rb.AddForce(Vector2.right * dir * base_speed);
	 float velocityY = rb.velocity.y;
	 if(rb.velocity.x > max_speed){
	  rb.velocity = new Vector2(max_speed, velocityY);
	 }else if(rb.velocity.x < -max_speed){
	 	rb.velocity = new Vector2(-max_speed, velocityY);
	 }
	 
	}

 private void OnCollisionEnter(Collision col){
  if(jumping){
   jumping = false;
  }
 }

}
