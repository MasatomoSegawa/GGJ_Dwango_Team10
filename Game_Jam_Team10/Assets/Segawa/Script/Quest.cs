using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quest : MonoBehaviour {

	// 表示用のテキスト.
	private Text textGUI;

	public string baseString = "エクソシストを";
	public string baseEndString = "匹生け贄に捧げよ!";

	[SerializeField]
	private int ritualOfNumber = 5;

	public delegate void EndQuest ();
	public EndQuest EndQuestEvent;

	void Start(){

		textGUI = transform.GetComponentInChildren<Text> ();

		UpdateUI ();

	}

	void Update(){

		/*
		if (Input.GetKeyDown (KeyCode.A)) {
			ReduceRitualOfNumber (1);
		}*/

	}

	public void ReduceRitualOfNumber(int number){

		ritualOfNumber = Mathf.Clamp (ritualOfNumber - number, 0, 100);
		if (ritualOfNumber <= 0) {
			if (EndQuestEvent != null) {
				EndQuestEvent ();
			}
		}

		UpdateUI ();

	}

	private void UpdateUI(){

		textGUI.text = baseString + ritualOfNumber.ToString () + baseEndString;

	}


}