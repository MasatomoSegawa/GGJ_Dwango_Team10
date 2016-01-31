using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

 [SerializeField]
 Character chara;

	[SerializeField]
	Animator animator;

	// Update is called once per frame
	void Update () {

	 float inputX = Input.GetAxis("Horizontal");
	 if(inputX > 0){
			inputX = 1f;
	 }else if(inputX < 0){
			inputX = -1f;
	 }
	  chara.Accel(inputX);
	   
		if(Input.GetKeyDown(KeyCode.Space)){
	  chara.Jump();
			animator.SetTrigger ("Jump");
	 }

		if(Input.GetKey(KeyCode.Z)){
	  chara.Attack();
			animator.SetTrigger ("OnAttack");
	 }

	 if(Input.GetKey(KeyCode.P)){
	  GetComponent<Pause>().PauseFunc();
	 }

		Rigidbody rb;
		if(rb = chara.GetComponent<Rigidbody> ()){

			animator.SetFloat ("VerticalSpeed", rb.velocity.y);

			if (rb.velocity.y <= 0.5f) {
			animator.SetBool ("isGround", true);
		} else {
			animator.SetBool ("isGround", false);

		}
	}
	}

}
