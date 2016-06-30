using UnityEngine;
using System.Collections;

public class MissileFade : MonoBehaviour {

  private float killme = 3;
  public bool owned_by_player = true;
  public GameObject UI;

  public AudioSource death1;
  public AudioSource death2;
  public AudioSource sfx_station_damage;

	// Use this for initialization
	void Start () {
	
	}
	
  public void OnTriggerEnter(Collider other){
    if(other.tag == "Enemy"){
      if(owned_by_player){
        Destroy(other.gameObject);
        Destroy(gameObject);//TODO HP
        UI.GetComponent<UIManager>().score++;
        if(Random.Range(0,1) == 1){
          death1.Play();
        } else {
          death2.Play();
        }
        for (int i = 1; i<= 100; i++){
          GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
          cube.GetComponent<Collider>().enabled = false;
          cube.transform.rotation = Random.rotation;
          Vector3 temp = transform.position + Random.insideUnitSphere*Random.Range(10,20);// - transform.forward*10;
          cube.transform.position = temp;
          cube.AddComponent<FadeOverTime>();
        }
      }
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
        sfx_station_damage.Play();
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
