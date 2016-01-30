using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

	private bool pausing = false;
	private float defaultTimeScale = 0f;

	[SerializeField]
	private Text text;

	// Use this for initialization
	void Start () {
		defaultTimeScale = Time.timeScale;
	}

	public void PauseFunc(){

	 pausing = !pausing;

	 Debug.Log( " Pause(" + pausing.ToString() + ") " );

	 text.enabled = pausing;

	 if(pausing){
	  Time.timeScale = 0;
	 }else{
	  Time.timeScale = defaultTimeScale;
	 }
	}
}
