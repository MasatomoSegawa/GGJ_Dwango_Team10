using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private float base_speed = 0.1f;
	private float accel = 0f;
	private float frictionRate = 2f; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	float add;
	if( Mathf.Abs( accel ) > 0f){
	 if(accel > 0){
		add = -Time.deltaTime;
	 }else{
		add = Time.deltaTime;
	 }
		accel += add * frictionRate;
	 }

	 Vector2 pos = transform.localPosition;
	 Vector2 newPos = pos + Vector2.right * (this.accel * base_speed);
	 transform.localPosition = newPos;

	}

	public void Jump(){
 	Debug.Log("Jump");
	}

	public void Accel(float dir){
	 this.accel = dir;
	}
}
