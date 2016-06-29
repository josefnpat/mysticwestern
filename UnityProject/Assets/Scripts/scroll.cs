using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {
	public float speed;
	public Vector3 orientation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(orientation * Time.deltaTime * speed);
	}
}
