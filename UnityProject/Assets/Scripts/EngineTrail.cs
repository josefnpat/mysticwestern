using UnityEngine;
using System.Collections;

public class EngineTrail : MonoBehaviour {

  private Rigidbody RB;
  private float next = 0;
	// Use this for initialization
	void Start () {
    RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
    next -= RB.velocity.magnitude / 100;
    if(next < 0){
      next = 1;
      GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
      cube.GetComponent<Collider>().enabled = false;
      Vector3 temp = transform.position - transform.forward*10;
      cube.transform.position = temp;
      cube.transform.rotation = Random.rotation;
      cube.AddComponent<FadeOverTime>();
    }
	}
}
