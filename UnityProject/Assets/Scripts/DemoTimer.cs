using UnityEngine;
using System.Collections;

public class DemoTimer : MonoBehaviour {
	public float maxTimeInSeconds;
	private float timeLeft;
	// Use this for initialization
	void Start () {
		timeLeft = maxTimeInSeconds;
	}
	
	// Update is called once per frame
	void Update()
	{
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			 Application.Quit();
		}
	}
}
