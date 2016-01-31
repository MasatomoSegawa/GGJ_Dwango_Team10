using UnityEngine;
using System.Collections;

public class ExorcistGenerator : MonoBehaviour {

[SerializeField]
private GameObject enemy;
[SerializeField]
private GameObject target;


	private float throwInterval = 5f;
	private float timer = 0f;

	private float maxOffset = 20f;
	private float verticalOffset = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	timer += Time.deltaTime;
	if(timer > throwInterval){
	timer = 0;
	Generate();
	 return;
	}
	}


	private void Generate(){
	GameObject obj = Instantiate(enemy);

	Vector3 pos = target.transform.position;

	float offsetX = Random.Range(-maxOffset, maxOffset);

	Vector3 birthPos = pos + new Vector3(offsetX, verticalOffset);
	obj.transform.position = birthPos;

	}
}
