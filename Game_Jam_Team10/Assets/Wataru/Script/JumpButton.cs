using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JumpButton : MonoBehaviour {

 [SerializeField]
 private IndicatorTest targetText;

	[SerializeField]
	private Character character;

	private RepeatButton repeat;

	// Use this for initialization
	void Start () {
		repeat = GetComponentInParent<RepeatButton>();

	}
	
	// Update is called once per frame
	void Update () {
		if(repeat.pressing){

	character.Jump();
		targetText.SetText("Jump");
}
	}
	/*
	public void Press(){
		Debug.Log("Jump");
		targetText.SetText("Jump");
	}
	*/

}
