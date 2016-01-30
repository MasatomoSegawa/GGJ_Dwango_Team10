using UnityEngine;
using System.Collections;

public class Jack : MonoBehaviour {

	private float life_dur = 3f;
	private float life_timer = 0f;

	// Use this for initialization
	void Start () {
	life_timer = life_dur;
	}
	
	// Update is called once per frame
	void Update () {
	life_timer -= Time.deltaTime;
	if(life_timer <= 0){
	Destroy(this.gameObject);
	}
	}
}
