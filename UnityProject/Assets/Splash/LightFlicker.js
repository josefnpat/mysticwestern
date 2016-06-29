#pragma strict

private var flicker = 0f;

private var init_intensity : float;

private var light_enabled : boolean;

function Start () {
  init_intensity = GetComponent.<Light>().intensity;
}

function Update () {
  flicker -= Time.deltaTime;
  if(flicker <= 0){
    if(light_enabled){
      GetComponent.<Light>().intensity = init_intensity;
      flicker = Random.Range(0.05,0.1);
    } else {
      GetComponent.<Light>().intensity = init_intensity/2;
      flicker = Random.Range(0.2,3.0);
    }
    light_enabled = !light_enabled;
  }
}
