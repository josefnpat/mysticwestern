using UnityEngine;
using System.Collections;

public class MissileFade : MonoBehaviour {

  private float killme = 3;
  public bool owned_by_player = true;

	// Use this for initialization
	void Start () {
	
	}
	
  public void OnTriggerEnter(Collider other){
    if(other.tag == "Enemy"){
      if(owned_by_player){
        Destroy(other.gameObject);
        Destroy(gameObject);//TODO HP
      }
      Debug.Log("enemy hit!");
    } else if(other.tag == "Player"){
      if(!owned_by_player){
        Debug.Log("player hit!");
        Destroy(gameObject);
        //TODO
      }
    } else if(other.tag == "Station") {
      if(!owned_by_player){
        Debug.Log("station hit!");
        Destroy(other.gameObject);
        //TODO
      }
    }
    Debug.Log(other.tag+" hit");
  }

	// Update is called once per frame
	void Update () {
    killme -= Time.deltaTime;
    if(killme < 0){
      Destroy(gameObject);
    }
	}
}
