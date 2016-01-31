using UnityEngine;
using System.Collections;

public class EndingLogic : MonoBehaviour {

	public void OnTitleButton(){
		FadeManager.Instance.LoadLevel ("Title",2.0f);
	}

}