using UnityEngine;
using System.Collections;

public class CollectPoint : MonoBehaviour {

[SerializeField]
private GameObject circle;

    private float timer = 0;
	private float appear_dur = 10; // 魔法陣移動までの時間

private float rotSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	// 魔法陣回転
	 circle.transform.Rotate(Vector3.up * rotSpeed);

	 //一定時間で移動
	 timer += Time.deltaTime;
	 if(timer >= appear_dur){
	  ChangePosition();
	 }

	}


	private void OnTriggerEnter(Collider col){
	if(col.tag.Equals( "Player" )){
	 col.GetComponent<Player>().Delivery();
	 ChangePosition();
	}

	}


	private void ChangePosition(){
	 GameObject[] stages = GameObject.FindGameObjectsWithTag("Structure");
	 int key = 0;
		bool haveCollectPoint;
	 // 魔法陣が出現していないステージパーツを移動先に設定
	 do{
		key = Random.Range(0, stages.Length);
        haveCollectPoint = false;
		for( int i = 0 ; i < stages[key].transform.childCount ; i++){
				if(stages[key].transform.GetChild(i).name.Contains("CollectPoint")){
				  haveCollectPoint = true;
				  break;
				}
		}
		}while(haveCollectPoint);

	 // ステージパーツの子要素にする
	 this.transform.SetParent( stages[key].transform );
	 this.transform.localPosition = Vector3.up * 0.75f;


	 timer = 0;
	}
}
