using UnityEngine;
using System.Collections;

public class SwapMaterialOnHover : MonoBehaviour {

  private Material orig_mat;
  public Material hover_mat;

  // Use this for initialization
  void Start () {
    orig_mat = GetComponent<Renderer>().material;
  }

  void OnMouseEnter(){
    GetComponent<Renderer>().material = hover_mat;
  }

  void OnMouseExit(){
    GetComponent<Renderer>().material = orig_mat;
  }

}
