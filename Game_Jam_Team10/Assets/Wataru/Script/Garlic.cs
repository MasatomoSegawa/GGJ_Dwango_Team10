using UnityEngine;
using System.Collections;

public class Garlic : MonoBehaviour {

private float lifeTime = 5;
private float timer = 0;
void Update(){
timer+= Time.deltaTime;
if(timer > lifeTime){
Destroy(this.gameObject);;
}
}
}
