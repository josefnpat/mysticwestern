using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

  private Rigidbody RB;
  private float ShipThrust;
  public float ShipThrustMax;

  public float VelocityMax;

  public float RollSpeed;
  public float PitchSpeed;
  public float YawSpeed;

  // Use this for initialization
  void Start () {
    RB = GetComponent<Rigidbody>();
    //ShipThrust = 0;
  }

  // Update is called once per frame
  void Update () {

    float r = Input.GetAxis("Roll KB&M");
    if(r == 0){ r = Input.GetAxis("Roll Joystick");}
    float p = Input.GetAxis("Pitch KB&M");
    if(p == 0){ p = Input.GetAxis("Pitch Joystick");}
    float y = Input.GetAxis("Yaw KB&M");
    if(y == 0){ y = Input.GetAxis("Yaw Joystick");}
    float t = Input.GetAxis("Thrust KB&M");
    if(t == 0){ t = Input.GetAxis("Thrust Joystick");}

    ShipThrust = Mathf.Min(
      ShipThrustMax,
      Mathf.Max(
        -ShipThrustMax,
        ShipThrust + t
      )
    );

    transform.Rotate(Vector3.forward*Time.deltaTime*r*RollSpeed);
    transform.Rotate(Vector3.right*Time.deltaTime*p*PitchSpeed);
    transform.Rotate(Vector3.up*Time.deltaTime*y*YawSpeed);

    if(Input.GetButton("Halt")){
      ShipThrust = 0;
      Vector3 tempv = RB.velocity;//*=0.9F;
      float Change = ShipThrustMax*Time.deltaTime;

      if(Mathf.Abs(tempv.x) < Change){
        tempv.x = 0;
      } else if(tempv.x > 0){
        tempv.x -= Change;
      } else if(tempv.x < 0){
        tempv.x += Change;
      }

      if(Mathf.Abs(tempv.y) < Change){
        tempv.y = 0;
      } else if(tempv.y > 0){
        tempv.y -= Change;
      } else if(tempv.y < 0){
        tempv.y += Change;
      }

      if(Mathf.Abs(tempv.z) < Change){
        tempv.z = 0;
      } else if(tempv.z > 0){
        tempv.z -= Change;
      } else if(tempv.z < 0){
        tempv.z += Change;
      }


      RB.velocity = tempv;
    } else {
      RB.AddForce(transform.forward * ShipThrust);
      Vector3 tempv = RB.velocity;
      tempv.x = Mathf.Min(VelocityMax,tempv.x);
      tempv.y = Mathf.Min(VelocityMax,tempv.y);
      tempv.z = Mathf.Min(VelocityMax,tempv.z);
      RB.velocity = tempv;
    }

  }
}
