using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveRButton : MonoBehaviour {

	[SerializeField]
	private Character character;

	private RepeatButton repeat;

	// Use this for initialization
	void Awake () {
	repeat = GetComponentInParent<RepeatButton>();
	}
	
	// Update is called once per frame
	void Update () {
	 if(repeat.pressing){
	  character.Accel(1);
 }else{

	 }

	}

}
