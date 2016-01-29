using UnityEngine;
using System.Collections;

public class RepeatButton : MonoBehaviour 
{
	public bool pressing = false; // ボタンが押されているか？

	public void StartPush()
	{
		pressing = true;
	}

	public void StopPush()
	{
		pressing = false;
	}

	void Update()
	{
		if(pressing)
		{
			//ここにやらせたい処理を書きます
//			Debug.Log("押されてます！");
		}
	}
}