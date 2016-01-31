using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Player : Character {

[SerializeField]
private GameObject jack;

	[SerializeField]
	private GameObject effect_consume;

	[SerializeField]
	private Quest quest;

	[SerializeField]
	private GameObject effect_die;

    public delegate void OnDelivery();
    public OnDelivery onDelivery;

	private Vector3 throw_force = new Vector3(500f, 300f);

	private List<GameObject> keeps = new List<GameObject>();

	public override event Die die;


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


	 foreach(GameObject g in keeps){
		g.AddComponent<Rigidbody>();
		g.GetComponent<Collider>().enabled = true;
		g.GetComponent<Collider>().isTrigger = true;
		Destroy(g, 1f);
	 }

	 keeps.Clear();
	 fixed_rate = 1f;

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

  fixed_rate = 1f;
   Destroy( obj.GetComponent<Rigidbody>());
   obj.GetComponent<Collider>().enabled = false;
   keeps.Add(obj);

   for(int i=0 ; i < keeps.Count ; i++){
    fixed_rate *= 0.9f;
   }

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

	 quest.ReduceRitualOfNumber(sum);

	 fixed_rate = 1f;
	 keeps.Clear();

	 Debug.Log("Got " + sum.ToString() + "  point!");

	}

	private void SendToUpper(GameObject obj, float delay){

	 // 屍体を上に飛ばす演出
		obj.transform.DOMoveY(5f, .7f).SetEase(Ease.InBack).SetDelay(delay).OnComplete(delegate {

	// 消滅エフェクト
	  GameObject e = Instantiate( effect_consume );
	  e.transform.position = obj.transform.position;

	  // 屍体オブジェクト削除
		Destroy ( obj );
		Destroy(e, 2f);

	  });
	}

	protected override void ChangeStateToDie(){
		StartCoroutine( ShowExpressionOfDie(2f) );
	}

	private IEnumerator ShowExpressionOfDie(float wait){


		SoundManager.Instance.FadeOutBGM(0);

	 Destroy( GetComponent<Rigidbody>() );
	 this.GetComponent<BoxCollider>().enabled = false;

	 // 砂になるエフェクト
	 GameObject obj = Instantiate( effect_die );
	 obj.transform.position = this.transform.position;

	 iTween.FadeTo (this.gameObject, 0f, wait);

	 yield return new WaitForSeconds( wait );

	 Destroy(obj, 5f);
	 if(die != null){
	  die();
	 }

	 // play gameover bgm
	 SoundManager.Instance.PlayBGM(1);
	}

	private IEnumerator PlaySeWithDelay(float delay){
		yield return new WaitForSeconds (delay);
		// play se
		SoundManager.Instance.PlaySE (4);
	}

}
