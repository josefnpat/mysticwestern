using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

  public float forward;
  public float right;
  public float up;
  void Start (){
  }
  void Update (){
    transform.Rotate(Vector3.forward * Time.deltaTime * forward);
    transform.Rotate(Vector3.right   * Time.deltaTime * right  );
    transform.Rotate(Vector3.up      * Time.deltaTime * up     );
  }
}
