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

  public GameObject missile;

  private float reload = 0;

  public GameObject cameras;
  public float camera_max_roll;
  public float camera_max_pitch;
  public float camera_max_yaw;

  public GameObject UI;

  public AudioSource sfx_shoot;
  public AudioSource sfx_death1;
  public AudioSource sfx_death2;
  public AudioSource sfx_engine;

  // Use this for initialization
  void Start () {
    RB = GetComponent<Rigidbody>();
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
        0,
        ShipThrust + t
      )
    );

    sfx_engine.volume = Mathf.Max(0,Mathf.Min(1,ShipThrust/ShipThrustMax/2));

    // Rotate ship
    transform.Rotate(Vector3.forward*Time.deltaTime*r*RollSpeed);
    transform.Rotate(Vector3.right*Time.deltaTime*p*PitchSpeed);
    transform.Rotate(Vector3.up*Time.deltaTime*y*YawSpeed);

    Quaternion newrot = cameras.transform.localRotation;

    // HACK COPY PASTE: Rotate camera
    if( r == 0 ){
      // return to zero
      if(newrot.z != 0){
        newrot.z -= Mathf.Sign(newrot.z)*Time.deltaTime;
      }
      if(Mathf.Abs(newrot.z) < Time.deltaTime){
        newrot.z = 0;
      }
    } else {
      newrot.z -= Time.deltaTime*r;
      newrot.z = Mathf.Min(camera_max_roll,Mathf.Max(-camera_max_roll,newrot.z));
    }
    if( p == 0 ){
      // return to zero
      if(newrot.x != 0){
        newrot.x -= Mathf.Sign(newrot.x)*Time.deltaTime;
      }
      if(Mathf.Abs(newrot.x) < Time.deltaTime){
        newrot.x = 0;
      }
    } else {
      newrot.x -= Time.deltaTime*p;
      newrot.x = Mathf.Min(camera_max_pitch,Mathf.Max(-camera_max_pitch,newrot.x));
    }
    if( y == 0 ){
      // return to zero
      if(newrot.y != 0){
        newrot.y -= Mathf.Sign(newrot.y)*Time.deltaTime;
      }
      if(Mathf.Abs(newrot.y) < Time.deltaTime){
        newrot.y = 0;
      }
    } else {
      newrot.y -= Time.deltaTime*y;
      newrot.y = Mathf.Min(camera_max_yaw,Mathf.Max(-camera_max_yaw,newrot.y));
    }

    cameras.transform.localRotation = newrot;

    reload -= Time.deltaTime;
    if(
        (
          Input.GetButton("Shoot KB&M") ||
          Input.GetAxis("Shoot Joystick") != 0 ||
          Input.GetAxis("Shoot Joystick Windows") != 0
        ) && reload < 0 ){
      reload = 0.1F;
      sfx_shoot.Play();
      GameObject tempmis = (GameObject) Instantiate(missile, transform.position, transform.rotation);
      tempmis.GetComponent<MissileFade>().UI = UI;
      tempmis.GetComponent<MissileFade>().death1 = sfx_death1;
      tempmis.GetComponent<MissileFade>().death2 = sfx_death2;
      Vector3 temp = transform.position + transform.forward*10;
      tempmis.transform.position = temp;
      Rigidbody tempbody = tempmis.GetComponent<Rigidbody>();
      tempbody.velocity = RB.velocity + transform.forward * 100;
    }

    if( t == 0 ){
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

    if(RB.velocity.magnitude > 100){
      RB.velocity = RB.velocity.normalized * 100;
    }

  }
}
