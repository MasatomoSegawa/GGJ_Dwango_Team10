using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveLButton : MonoBehaviour {
	[SerializeField]
	private IndicatorTest targetText;

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
	  character.Accel(-1f);
			targetText.SetText("<");
}else{

	 }

	}
	/*
	public void Press(){
		Debug.Log("<");
		targetText.SetText("<");
		character.Accel(-1);
	}
	*/
}
