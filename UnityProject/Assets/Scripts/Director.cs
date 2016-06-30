using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

  public GameObject enemy_prefab;
  public GameObject player;
  public GameObject station;
  public GameObject UI;

  private float spawn = 0;
  private float spawn_dt = 10;

	// Use this for initialization
	void Start () {
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
    spawn -= Time.deltaTime;
    if( spawn <= 0 ){
      spawn = spawn_dt;
      spawn_dt = Mathf.Max(0.1F,spawn_dt - 0.05F);
      makeEnemy();
      Debug.Log(spawn_dt);
    }
	}
}
