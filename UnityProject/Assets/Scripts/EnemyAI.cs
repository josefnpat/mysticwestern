﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

  public GameObject player;
  public GameObject station;

  public GameObject missile;

  private Rigidbody RB;

  private float reload = 0;

  public GameObject UI;

  public AudioSource death1;
  public AudioSource death2;
  public AudioSource sfx_station_damage;

	void Start () {
    RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
    float pdist = Vector3.Distance(transform.position,player.transform.position)/4;
    float sdist = Vector3.Distance(transform.position,station.transform.position);
    if( pdist < sdist ){
      transform.LookAt(player.transform.position);
    } else {
      transform.LookAt(station.transform.position);
    }

    RB.velocity = RB.velocity + transform.forward*1;

    if(RB.velocity.magnitude > 100){
      RB.velocity = RB.velocity.normalized * 100;
    }

    reload -= Time.deltaTime;
    if( pdist < 100 || sdist < 100){

      if( reload < 0 ){
        reload = 0.5F;
        GameObject tempmis = (GameObject) Instantiate(missile, transform.position, transform.rotation);
        tempmis.GetComponent<MissileFade>().UI = UI;
        tempmis.GetComponent<MissileFade>().death1 = death1;
        tempmis.GetComponent<MissileFade>().death2 = death2;
        tempmis.GetComponent<MissileFade>().sfx_station_damage = sfx_station_damage;
        tempmis.GetComponent<MissileFade>().owned_by_player = false;
        Vector3 temp = transform.position + transform.forward*10;
        tempmis.transform.position = temp;
        Rigidbody tempbody = tempmis.GetComponent<Rigidbody>();
        tempbody.velocity = RB.velocity + transform.forward * 100;
      }

    }

	}
}
