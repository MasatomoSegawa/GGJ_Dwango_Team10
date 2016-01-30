using UnityEngine;
using System.Collections;

public class WarpZone : MonoBehaviour {

[SerializeField]
private GameObject warpEnd;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider col){
	 if(col.gameObject.tag.Equals("Player")){
	  Warp(col.gameObject);
	 }
	}


	private void Warp(GameObject target){
	Debug.Log("Warp");
		Vector3 pawnPos = new Vector3(warpEnd.transform.position.x, target.transform.position.y, target.transform.position.z);
		target.transform.position = pawnPos;
	}
}
