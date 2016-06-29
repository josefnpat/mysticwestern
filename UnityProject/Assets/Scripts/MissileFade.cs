using UnityEngine;
using System.Collections;

public class MissileFade : MonoBehaviour {

  private float killme = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  killme -= Time.deltaTime;
    if(killme < 0){
      Destroy(gameObject);
    }
	}
}
