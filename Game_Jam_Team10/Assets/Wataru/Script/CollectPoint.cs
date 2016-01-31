using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CollectPoint : MonoBehaviour {

[SerializeField]
private GameObject circle;
	[SerializeField]
private GameObject circle2;
    private float timer = 0;
	private float appear_dur = 10; // 魔法陣移動までの時間

	private float rotSpeed = 1f;
	private float rotSpeed2 = 0.5f;


	private bool expressing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	// 魔法陣回転
		circle.transform.Rotate(Vector3.up * rotSpeed);
		circle2.transform.Rotate(Vector3.down * rotSpeed2);

	if(	expressing ){
	 return;
	}

	 //一定時間で移動
	 timer += Time.deltaTime;
	 if(timer >= appear_dur){
	  ChangePosition();
	 }

	}


	private void OnTriggerEnter(Collider col){
	if(col.tag.Equals( "Player" )){
	 col.GetComponent<Player>().Delivery();
	 Exetuce();
	}

	}

	private void Exetuce(){
	Debug.Log("Execute");
	expressing = true;



	 circle.transform.GetChild(0).GetComponent<SpriteRenderer>().DOFade(0f, 1.5f);
	 circle.transform.DOScale(3f, 1.5f).OnComplete(delegate {
	 circle.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
	 circle.transform.localScale = Vector3.one;
	 	ChangePosition();
	 });
	}


	private void ChangePosition(){

	expressing = false;

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
