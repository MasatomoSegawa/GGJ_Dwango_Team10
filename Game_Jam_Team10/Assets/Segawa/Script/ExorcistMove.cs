using UnityEngine;
using System.Collections;

public class ExorcistMove : MonoBehaviour {

	[SerializeField] private GameObject player;
	[SerializeField] GameObject exorcist;

	void Start()
	{
		StartCoroutine(generateExo());
	}
	IEnumerator generateExo()
	{
		yield return new WaitForSeconds(5f);
		Vector3 playerPoint = PlayerPoint(player);
		Vector3 createExorcistPoint = CreateExorcistPoint(playerPoint);
		Instantiate(exorcist, createExorcistPoint, Quaternion.identity);
	}

	void Update()
	{

	}


	public Vector3 PlayerPoint(GameObject player)
	{
		player.transform.position = this.transform.position;
		Vector3 playerPoint = player.transform.position;
		return playerPoint;
	}

	public Vector3 CreateExorcistPoint(Vector3 playerPoint){
		Vector3 createExorcistPoint = new Vector3(UnityEngine.Random.Range(-50.0F, 50.0F), playerPoint.y, playerPoint.z);
		return createExorcistPoint;
	}
}