using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGManager : MonoBehaviour {


[SerializeField]
private Transform target;

	private List<SpriteRenderer> bgImage = new List<SpriteRenderer>();
	private float distance = 0;

	private float switch_interval = 5f;
	private float timer = 0f;

	[SerializeField]
	Sprite[] images;

	[SerializeField]
	private Timer time_info;

	private int image_idx = 0;

	// tmp
	private float tmptimer  = 0f; 
	private float tmptimer_max = 15f; 
	private float bg_change_interval = 0;

	// Use this for initialization
	void Start () {
	 for(int i = 0 ; i <  transform.childCount ; i++){
	  bgImage.Add(transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());
	  tmptimer_max = time_info.currentTime;
	  bg_change_interval = tmptimer_max / images.Length;
	 } 

	 // 背景２枚の時限定
	 distance = bgImage[0].transform.localPosition.x - bgImage[1].transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	 if(timer >= switch_interval){
	  timer = 0;
	  JudgeAndReplaceBgImage();
	 }

	//Debug.Log( time_info.EveryHourTime );

	if(image_idx >= images.Length){
	return;
	}

	 tmptimer += Time.deltaTime;

	 if(tmptimer > bg_change_interval * (image_idx+1) && image_idx != tmptimer / bg_change_interval){
	  ChangeBgImage();
	 }
	}

	private void JudgeAndReplaceBgImage(){

	// プレイヤー位置を背景画像の距離単位で取得
		int numOfTargetPosUnit = (int)Mathf.Floor( target.transform.position.x / distance);

		foreach(SpriteRenderer g in bgImage){
			Vector3 pos = g.transform.position;
			float modfiedPos =  distance * ( bgImage.IndexOf( g ) == 0 ? numOfTargetPosUnit : numOfTargetPosUnit+1 );
			Vector3 newPos = new Vector3(modfiedPos, pos.y, pos.z);
			g.transform.position = newPos;
		}
	}

	private void ChangeBgImage(){
		image_idx = (int)(tmptimer / bg_change_interval);
		if(image_idx >= images.Length){
	     return;
	    }
		foreach(SpriteRenderer s in bgImage){
		 s.sprite = images[image_idx];
		}
	}
}
