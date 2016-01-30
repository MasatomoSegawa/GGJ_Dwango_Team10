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
}
