using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverEffect : MonoBehaviour {

	private CanvasGroup canvasGroup;
	private float startTime;
	private float timeDuration;
	private bool isPlay;

	void Start(){
		canvasGroup = GetComponent<CanvasGroup> ();
	}

	public void SetEffect(float duration){

		startTime = Time.timeSinceLevelLoad;
		isPlay = true;
		timeDuration = duration;

	}

	void Update(){

		if (isPlay == false) {
			return;
		}

		float diff = Time.timeSinceLevelLoad - startTime;
		if (diff >= timeDuration) {
			isPlay = false;
			canvasGroup.interactable = true;
			canvasGroup.alpha = 1.0f;
			canvasGroup.blocksRaycasts = true;
		}

		float rate = diff / timeDuration;

		canvasGroup.alpha = Mathf.Lerp (0.0f, 1.0f, rate);
	}

}
