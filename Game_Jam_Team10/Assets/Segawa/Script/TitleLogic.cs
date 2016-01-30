using UnityEngine;
using System.Collections;

public class TitleLogic : MonoBehaviour {

	void Start(){

		TitleStart ();

	}

	/// <summary>
	/// タイトルスタート.
	/// </summary>
	void TitleStart(){
		SoundManager.Instance.PlayBGM (0);
	}

	/// <summary>
	/// スタートボタンが押された時に呼び出される.
	/// </summary>
	public void OnStartButton(){

		SoundManager.Instance.FadeOutBGM (0);
		FadeManager.Instance.LoadLevel ("Main", 1.0f);

	}

}