using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

[SerializeField]
private Character target;

private Vector3 offset = new Vector3(0, 3f, -10f);

	private bool focusing = true;


	void Start(){
		target.die += () => Defocus();
 }

	// Update is called once per frame
	void Update () {


	if(!focusing){
	return;
	}


	this.transform.localPosition = target.transform.localPosition + offset;
	this.transform.LookAt(target.transform.position);
	}

	private void Defocus(){
	// プレイヤーを追いかけるのをやめる
	Debug.Log("Defocus!");
	focusing = false;
	}
}
