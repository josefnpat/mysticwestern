#pragma strict

private var init_intensity: float;

function Start () {
  init_intensity = GetComponent.<Light>().intensity;
}

function Update () {
  GetComponent.<Light>().intensity =
    Fade.value*init_intensity;
}
