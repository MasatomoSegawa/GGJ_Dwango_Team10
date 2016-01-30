using UnityEngine;
using System.Collections;

public class Jack : MonoBehaviour {

	private float life_dur = 3f;
	private float life_timer = 0f;


	[SerializeField]
	private GameObject effectPrefab;
	private GameObject effect;

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

	private void Collapse(){
	Debug.Log( "Collapse" );
	 effect = Instantiate(effectPrefab);
	 effect.transform.position = transform.position;
	 GetComponent<Collider>().enabled = false;
	 transform.GetChild(0).gameObject.SetActive(false);

	 Destroy(this.gameObject, 1f);
	}

	private void OnCollisionEnter(Collision col){
	 if(col.gameObject.tag.Equals("Enemy")){
		Collapse();
     }
	}

	private void OnDestroy(){
	 if(effect != null){
	  Destroy(effect);
	 }
	}
}
