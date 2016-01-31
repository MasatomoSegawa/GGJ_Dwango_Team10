using UnityEngine;
using System.Collections;

public class Exorcist : MonoBehaviour {

[SerializeField]
private GameObject garlic;

private Transform target;

	private float throwInterval = 1f;
	private float timer = 0f;


[SerializeField]
private float findRange = 10f;

	// Use this for initialization
	void Start () {
	target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

	timer += Time.deltaTime;
	if(timer < throwInterval){
	 return;
	}

	 if(JudgeInRange()){
	  FaceToTarget();
	  timer = 0f;
	  ThrowGarlic();
	 }

	}

	private void FaceToTarget(){
	 Vector3 myPos = transform.position;
	 Vector3 targetPos = target.transform.position;
     Vector3 scl = transform.localScale;
     Vector3 newScl;

	 if(myPos.x > targetPos.x){
	  newScl = new Vector3(-1, scl.y, scl.z);
	 }else{
	  newScl = new Vector3(1, scl.y, scl.z);
	 }
	 transform.localScale = newScl;
	}


	private bool JudgeInRange(){
	 Vector3 myPos = transform.position;
	 Vector3 targetPos = target.transform.position;

	 float distance = Mathf.Abs( (myPos - targetPos).magnitude );

	 return distance <= findRange;
	}


	private void ThrowGarlic(){

		Vector3 myPos = transform.position;
	 Vector3 targetPos = target.transform.position;

	// にんにくを生成
	GameObject obj = Instantiate(garlic);
	obj.transform.position = myPos;

		Vector3 dir = (targetPos - myPos).normalized;

		obj.GetComponent<Rigidbody>().AddForce(dir * 250);





	}
}
