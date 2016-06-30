using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

  public GameObject enemy_prefab;
  public GameObject player;
  public GameObject station;
  public GameObject UI;

  private float spawn = 0;
  private float spawn_dt = 10;

  public AudioSource death1;
  public AudioSource death2;
  public AudioSource sfx_station_damage;

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
    tempep.GetComponent<EnemyAI>().death1 = death1;
    tempep.GetComponent<EnemyAI>().death2 = death2;
    tempep.GetComponent<EnemyAI>().sfx_station_damage = sfx_station_damage;
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
