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


	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			bgImage.Add (transform.GetChild (i).GetComponent<SpriteRenderer>());

		}

		// 背景２枚の時限定
		distance = bgImage [0].transform.localPosition.x - bgImage [1].transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	 if(timer >= switch_interval){
	  timer = 0;
	  JudgeAndReplaceBgImage();
	 }



		Debug.Log(  time_info.currentTime.ToString() + " / " + time_info.EveryHourTime.ToString() );

		if(time_info.currentTime > time_info.EveryHourTime){
		 return;
		}


	FadePrevImage();

		
	if(image_idx >= images.Length){
	return;
	}

	 if(image_idx != time_info.currentTime){
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
		image_idx = time_info.currentTime; 
		if(image_idx >= images.Length){
	     return;
	    }

		foreach(SpriteRenderer s in bgImage){
		 GameObject obj = new GameObject();
		 obj.transform.SetParent( s.transform );
		 obj.transform.localPosition = Vector3.back * 0.1f;
		 obj.transform.localScale = Vector3.one;
		 SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
		 sr.sprite = s.sprite;
		 s.sprite = images[image_idx];
		}
	}


	private void FadePrevImage(){

	foreach(SpriteRenderer s in bgImage){
	 if(s.transform.childCount >= 1){
	  Color col = s.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
	  float alpha = col.a -= Time.deltaTime;
	  if(alpha <= 0){
	   Destroy(s.transform.GetChild(0).gameObject);
	  }else{
	   Color newCol = new Color(1f,1f,1f,alpha);
	   s.transform.GetChild(0).GetComponent<SpriteRenderer>().color = newCol;
	  }
	 }
	}

	}


}
