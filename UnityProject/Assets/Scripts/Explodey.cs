using UnityEngine;
using System.Collections;

public class Explodey : MonoBehaviour {

  public GameObject enemy_prefab;
  public TextMesh scoretext;

	// Use this for initialization
	void Start () {
    for (int i = 1; i<= 200; i++){
      GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
      cube.GetComponent<Collider>().enabled = false;
      cube.transform.rotation = Random.rotation;
      Vector3 temp = transform.position + Random.insideUnitSphere*Random.Range(10,20);// - transform.forward*10;
      cube.transform.position = temp;
    }
    scoretext.text = "Score: "+ PlayerPrefs.GetString("LastScore","-1") + "\n"+
      "Top Score: "+PlayerPrefs.GetString("TopScore","0");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
