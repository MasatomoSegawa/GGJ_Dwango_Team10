using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGManager : MonoBehaviour {


[SerializeField]
private Transform target;

	private List<GameObject> bgImage = new List<GameObject>();
	private float distance = 0;

	private float switch_interval = 5f;
	private float timer = 0f;

	// Use this for initialization
	void Start () {
	 for(int i = 0 ; i <  transform.childCount ; i++){
	  bgImage.Add(transform.GetChild(i).gameObject);
	 } 

	 // 背景２枚の時限定
	 distance = bgImage[0].transform.localPosition.x - bgImage[1].transform.localPosition.x;

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	 if(timer >= switch_interval){
	  timer = 0;
	  JudgeAndSwitchBgImage();
	 }
	}

	private void JudgeAndSwitchBgImage(){

	// プレイヤー位置を背景画像の距離単位で取得
		int numOfTargetPosUnit = (int)Mathf.Floor( target.transform.position.x / distance);

		foreach(GameObject g in bgImage){
			Vector3 pos = g.transform.position;
			float modfiedPos =  distance * ( bgImage.IndexOf( g ) == 0 ? numOfTargetPosUnit : numOfTargetPosUnit+1 );
			Vector3 newPos = new Vector3(modfiedPos, pos.y, pos.z);
			g.transform.position = newPos;
		}
	}
}
