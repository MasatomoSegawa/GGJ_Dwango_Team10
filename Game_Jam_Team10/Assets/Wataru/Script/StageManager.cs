using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour {

[SerializeField]
private Transform target;

	private float loop_range = 100;

	[SerializeField]
	private GameObject indicatorPrefab;
	private GameObject indicatorR;
	private GameObject indicatorL;

	GameObject[] stageParts;

	private float switch_interval = 1f;
	private float timer = 0f;

	private void Start(){

	//ステージパーツを登録
	 stageParts = GameObject.FindGameObjectsWithTag ("Structure");

	 float min = 9999;
	 float max = -9999;

	 Vector3 sum = Vector3.zero;

	 // ループ範囲を定義
	foreach(GameObject g in stageParts){
	 if(g.transform.position.x > max){
		max = g.transform.position.x;
	 }else if(g.transform.position.x < min){
	    min = g.transform.position.x;
	 } 

	 sum += g.transform.position;

	}
	loop_range = Mathf.Abs( max - min ) * 0.5f;

	//Vector3 center = sum / stageParts.Length;
	//target.position = new Vector3 (center.x, target.position.y);

	// インジケータ生成
		indicatorL = Instantiate(indicatorPrefab);
		indicatorR = Instantiate(indicatorPrefab);

	}

	private void Update(){

	timer += Time.deltaTime;
	if(timer >= switch_interval){
	 timer = 0;
	 SearchSwitchCandidate();
	}

	// インジケータの位置を更新
	indicatorL.transform.position = target.position + (Vector3.left * loop_range);
	indicatorR.transform.position = target.position + (Vector3.right * loop_range);


	}

	private void SearchSwitchCandidate(){

	// 範囲外のステージパーツ
	List<GameObject> outOfRanges = new List<GameObject>();

	// 範囲外のみ追加
		foreach(GameObject g in stageParts){
		float distance = Mathf.Abs( g.transform.position.x - target.position.x );
		 if(distance >= loop_range){
		 outOfRanges.Add(g);
		 }
        }
        // 範囲外のパーツがない時は終了
        if(outOfRanges.Count <= 0){
         return;
        }

        // 範囲外のパーツのうち一番遠いパーツを取得
		GameObject switchTarget = GetFarestOne(outOfRanges);

		// 全パーツの中心点を求めるための数 位置を変更するパーツは除外
		Vector3 sum = Vector3.zero;
		foreach(GameObject g in stageParts){
		 if(g != switchTarget){
		  sum += g.transform.position;
 		 }
		}
		Vector3 pos = switchTarget.transform.position;

		//パーツの中心点
		Vector3 center = sum / (stageParts.Length-1);

		// 中心天からの距離
		float diff = switchTarget.transform.position.x - center.x;
		float newPosX = center.x - diff;
	   Vector3 newPos = new Vector3(newPosX, pos.y, pos.z);

	   // 位置変更対象のパーツの位置を更新
	  switchTarget.transform.position = newPos;
	 
	}

	private float GetDistanceFromCenter(GameObject obj){
	Vector3 sum = Vector3.zero;

	foreach(GameObject g in stageParts){
	 Vector3 pos = g.transform.position;
			sum += pos;
	 }
	 Vector3 center = sum / stageParts.Length;
	 float diff = Mathf.Abs( center.x - obj.transform.position.x );
	 return diff;
	}

	private GameObject GetFarestOne(List<GameObject> objs){
	GameObject obj = objs[0];

	foreach(GameObject g in objs){
			if(GetDistanceFromCenter(g) > GetDistanceFromCenter(obj)){
			 obj = g;
			}
	}
	 return obj;
	} 

}
