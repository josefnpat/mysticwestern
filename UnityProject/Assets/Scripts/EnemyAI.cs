using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

  public GameObject player;
  public GameObject station;

  public GameObject missile;

  private Rigidbody RB;

  private float reload = 0;

	void Start () {
    RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
    float pdist = Vector3.Distance(transform.position,player.transform.position);
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
        reload = 0.1F;
        Debug.Log("shoot");
        GameObject tempmis = (GameObject) Instantiate(missile, transform.position, transform.rotation);
        Vector3 temp = transform.position + transform.forward*10;
        tempmis.transform.position = temp;
        Rigidbody tempbody = tempmis.GetComponent<Rigidbody>();
        tempbody.velocity = RB.velocity + transform.forward * 100;
      }

      Debug.Log("Shooting you!");
    }

	}
}
