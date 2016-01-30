using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {

	[SerializeField]
	private Pause pause;

	private RepeatButton repeat;

	private bool pressedOnce = false;

	// Use this for initialization
	void Start () {
		repeat = GetComponentInParent<RepeatButton>();
	}
	
	// Update is called once per frame
	void Update () {
		if(repeat.pressing){
		  if(!pressedOnce){
		   pressedOnce = true;
		   pause.PauseFunc();
		  }
         }else{
         if(pressedOnce){
          pressedOnce = false;
         }
         }
	}
}
