using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {

[SerializeField]
private Transform target;


	private float loop_range = 500;

	GameObject[] stageParts;

	private void Start(){
	 stageParts = GameObject.FindGameObjectsWithTag ("Structure");
	}

	private void Update(){
	foreach(GameObject g in stageParts){
	//if(g.transform.
	}


	}


}
