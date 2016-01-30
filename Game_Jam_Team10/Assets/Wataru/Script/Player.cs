using UnityEngine;
using System.Collections;

public class Player : Character {

[SerializeField]
private GameObject jack;

	private Vector3 throw_force = new Vector3(500f, 300f);

	protected override void Awake ()
	{
		base.Awake ();
		attack_interval = 0.5f;
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
   if(damage_wait <= 0){
    ApplyDamage(1);
    }
   }else{
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

}
