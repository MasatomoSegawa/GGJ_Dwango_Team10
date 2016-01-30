using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthGauge : MonoBehaviour {

[SerializeField]
private Image fill;

[SerializeField]
private Character target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	float percent = target.health / target.max_health;

	Vector3 newScl = new Vector3(percent, 1f);
	fill.transform.localScale = newScl;

	}
}
