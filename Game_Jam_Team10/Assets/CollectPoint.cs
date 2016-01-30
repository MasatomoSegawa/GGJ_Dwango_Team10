using UnityEngine;
using System.Collections;

public class CollectPoint : MonoBehaviour {

[SerializeField]
private GameObject circle;

private float rotSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 circle.transform.Rotate(Vector3.up * rotSpeed);
	}


	private void OnTriggerEnter(Collider col){
	if(col.tag.Equals( "Player" )){
	 col.GetComponent<Player>().Delivery();
	 ChangePosition();
	}

	}


	private void ChangePosition(){
	GameObject[] stages = GameObject.FindGameObjectsWithTag("Structure");

	bool defined = false;

	foreach(GameObject g in stages){
	 if(Random.Range(0, 2) == 0){
	  defined = true;
	  this.transform.SetParent( g.transform );
	  break;
	 } 
	}

	if(!defined){
		this.transform.SetParent( stages[0].transform );
	}

	this.transform.localPosition = Vector3.up * 0.5f;


	}
}
