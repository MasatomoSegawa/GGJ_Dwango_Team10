using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character {

[SerializeField]
private GameObject jack;


public delegate void OnDelivery();
public OnDelivery onDelivery;

	private Vector3 throw_force = new Vector3(500f, 300f);

	private List<GameObject> keeps = new List<GameObject>();


	protected override void Awake ()
	{
		base.Awake ();
		attack_interval = 0.5f;
	}

	protected override void Update ()
	{
		base.Update ();

		UpdateKeeps();
	}

	private void UpdateKeeps(){
	int num = 1;
	float interval = 0.5f;

	foreach(GameObject g in keeps){
	 g.transform.position = this.transform.position + new Vector3(0f, interval * num, -0.25f);
	 num++;
	}


	}


public override void ExecuteAttack ()
	{
	GameObject obj = Instantiate(jack);
	obj.transform.position = this.transform.position;

	Vector3 force = new Vector3(throw_force.x * (flipRight ? 1 : -1), throw_force.y);;
		obj.GetComponent<Rigidbody>().AddForce(force);
	}


	protected override void OnCollisionEnter(Collision col){
	base.OnCollisionEnter(col);
  if(col.gameObject.tag.Equals("Enemy")){
  // 敵
   if( col.gameObject.GetComponent<EnemyController>().dead ){
    AddToKeep(col.gameObject);
   }else{
	if(damage_wait <= 0){
     ApplyDamage(1);
    }
   }


   }else{
   // 地面
    if(jumping){
     jumping = false;
    }
  }
 }

	public override void ApplyDamage(int val){
    base.ApplyDamage(val);

// play se
 SoundManager.Instance.PlaySE(2);
	}

	protected override void OnTriggerEnter(Collider col){

	if(col.gameObject.tag.Equals("DeadZone")){
	//即死
	 ApplyDamage(999);
	}
 }
  public void AddToKeep(GameObject obj){
   obj.GetComponent<Rigidbody>().Sleep();
   obj.GetComponent<Collider>().enabled = false;
   keeps.Add(obj);

  }


	public void Delivery(){

	if( onDelivery != null){
	 onDelivery();
	}

	int sum = 0;
	 foreach(GameObject g in keeps){
			StartCoroutine(PlaySeWithDelay(sum * 0.35f ));

	  sum++;
	  Destroy ( g );
	 }




	 keeps.Clear();

	 Debug.Log("Got " + sum.ToString() + "  point!");

	}

	private IEnumerator PlaySeWithDelay(float delay){
	 yield return new WaitForSeconds(delay);
		// play se
	 SoundManager.Instance.PlaySE(3);
	}

}
