using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeStateOnClick : MonoBehaviour {

  public string targetScene = "";

  void OnMouseUp() {
    if(targetScene == ""){
      Debug.Log("Goodbye space cowboy.");
      Application.Quit();
    } else {
      SceneManager.LoadScene(targetScene);
    }
  }

}
