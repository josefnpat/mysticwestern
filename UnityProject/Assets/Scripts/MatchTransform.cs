using UnityEngine;
using System.Collections;

public class MatchTransform : MonoBehaviour {

  public GameObject target;

  // Update is called once per frame
  void Update () {
    transform.position = target.transform.position;
    transform.rotation = target.transform.rotation;
  }
}
