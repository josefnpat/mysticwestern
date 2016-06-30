using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

  public GameObject enemy_prefab;
  public GameObject player;
  public GameObject station;
  public GameObject UI;

	// Use this for initialization
	void Start () {
    for (int i = 1; i <= 10; i++){
      makeEnemy();
    }
	}

  void makeEnemy() {
    GameObject tempep = (GameObject) Instantiate(
      enemy_prefab,
      Random.insideUnitSphere * Random.Range(3000,3200),
      Random.rotation
    );
    tempep.GetComponent<EnemyAI>().player = player;
    tempep.GetComponent<EnemyAI>().station = station;
    tempep.GetComponent<EnemyAI>().UI = UI;
  }
	
	// Update is called once per frame
	void Update () {
	
	}
}
