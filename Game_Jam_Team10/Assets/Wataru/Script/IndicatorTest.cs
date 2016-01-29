using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IndicatorTest : MonoBehaviour {

private Text myText;
	private const float dur = 3f;
	private float timer = 0f;

	// Use this for initialization
	void Start () {
	myText = GetComponent<Text>();
	myText.enabled = false;
	timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	if(timer > dur){
	 timer-= Time.deltaTime;
	if(timer <= 0){
	 myText.enabled = false;
	}

	}
	}

	public void SetText(string text){
	 myText.enabled = true;
	 myText.text = text;
	 timer = dur;
	}
}
