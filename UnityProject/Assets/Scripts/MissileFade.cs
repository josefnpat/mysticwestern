using UnityEngine;
using System.Collections;

public class MissileFade : MonoBehaviour {

  private float killme = 3;
  public bool owned_by_player = true;
  public GameObject UI;

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
        UI.GetComponent<UIManager>().shield -= 0.05F;
        if(UI.GetComponent<UIManager>().shield < 0){
          UI.GetComponent<UIManager>().health = Mathf.Max(
            0,
            UI.GetComponent<UIManager>().health + UI.GetComponent<UIManager>().shield
          );
          UI.GetComponent<UIManager>().shield = 0;
        }
        Destroy(gameObject);
        //TODO LOSE
      }
    } else if(other.tag == "Station") {
      if(!owned_by_player){
        Destroy(gameObject);
        //TODO LOSE
        UI.GetComponent<UIManager>().energy = Mathf.Max(
          0,
          UI.GetComponent<UIManager>().energy - 0.0125F
        );
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
