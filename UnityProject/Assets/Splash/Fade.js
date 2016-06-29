#pragma strict

var fade_in_time : float = 4;
private var fade_in_time_dt : float = 0;

var idle_time : float = 4;
private var idle_time_dt : float = 0;

var fade_out_time : float = 4;
private var fade_out_time_dt : float = 0;

static var value = 0.0;

var next_scene : String;

private var skip : boolean = false;
var skip_speed : float = 3;

function Update () {

  if(Input.anyKeyDown&&fade_in_time_dt>0.1){
    skip = true;
  }

  var dt = Time.deltaTime;
  if(skip){
    dt=dt*skip_speed;
  }

  if(fade_in_time_dt < fade_in_time){ //fade in
    fade_in_time_dt += dt;
    value = Mathf.Sin(fade_in_time_dt / fade_in_time * Mathf.PI/2);
  } else if(idle_time_dt < idle_time){ //idle
    idle_time_dt += dt;
    value = 1.0;
  } else if(fade_out_time_dt < fade_out_time) { //fade out
    fade_out_time_dt += dt;
    value = Mathf.Sin(1-(fade_out_time_dt / fade_out_time) * Mathf.PI/2);
  } else { //idle
    Application.LoadLevel(next_scene);
  }
}
