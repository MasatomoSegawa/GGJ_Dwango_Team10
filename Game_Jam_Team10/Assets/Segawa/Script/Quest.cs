using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quest : MonoBehaviour {

	// 表示用のテキスト.
	private Text textGUI;

	void Start(){

		textGUI = transform.GetComponentInChildren<Text> ();

	}

	public void SetQuest(string questTitle){

		textGUI.text = questTitle;

	}

	/*
	IEnumerator StartQuest(){



	}*/

}