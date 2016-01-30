using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

[SerializeField]
private Transform target;

private Vector3 offset = Vector3.back * 10f;
	
	// Update is called once per frame
	void Update () {
	this.transform.localPosition = target.localPosition + offset;
	}
}
