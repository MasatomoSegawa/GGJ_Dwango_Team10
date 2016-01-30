using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

 [SerializeField]
 Character chara;

	// Update is called once per frame
	void Update () {
	 float inputX = Input.GetAxis("Horizontal");
	 if(inputX > 0){
			inputX = 1f;
	 }else if(inputX < 0){
			inputX = -1f;
	 }
	  chara.Accel(inputX);
	   
	 if(Input.GetKey(KeyCode.Space)){
	  chara.Jump();
	 }

		if(Input.GetKey(KeyCode.Z)){
	  chara.Attack();
	 }

	}
}
