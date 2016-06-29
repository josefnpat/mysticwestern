using UnityEngine;
using System.Collections;

public class FadeOverTime : MonoBehaviour {

  private float killmemax = 3;
  private float killme = 3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    killme -= Time.deltaTime;
    transform.localScale = new Vector3(killme/killmemax,killme/killmemax,killme/killmemax);
    if(killme < 0){
      Destroy (gameObject);
    }
	}
}
