using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Player : Character {

[SerializeField]
private GameObject jack;

	[SerializeField]
	private GameObject effect_consume;


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
	float basePos = 1f;

	foreach(GameObject g in keeps){
	 g.transform.position = this.transform.position + new Vector3(0f, basePos + interval * num , -0.25f);
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
   Destroy( obj.GetComponent<Rigidbody>());
   obj.GetComponent<Collider>().enabled = false;
   keeps.Add(obj);

   // Play se
   SoundManager.Instance.PlaySE(4);

  }


	public void Delivery(){

	if( onDelivery != null){
	 onDelivery();
	}

	int sum = 0;
	 foreach(GameObject g in keeps){
	 StartCoroutine(PlaySeWithDelay(sum * 0.35f ));
	  sum++;

	  SendToUpper(g, sum * 0.1f);

	 }
	 keeps.Clear();

	 Debug.Log("Got " + sum.ToString() + "  point!");

	}

	private void SendToUpper(GameObject obj, float delay){
		obj.transform.DOMoveY(5f, .7f).SetEase(Ease.InBack).SetDelay(delay).OnComplete(delegate {

	  GameObject e = Instantiate( effect_consume );
	  e.transform.position = obj.transform.position;
		Destroy ( obj );
		Destroy(e, 2f);

	  });
	}

	private IEnumerator PlaySeWithDelay(float delay){
	 yield return new WaitForSeconds(delay);
		// play se
	 SoundManager.Instance.PlaySE(3);
	}

}
