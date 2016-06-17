using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

  /*
  public string dialog_name;
  public string dialog_text;
  public string dialog_audio;
  public string dialog_yes;
  public string dialog_yes_action;
  public string dialog_no;
  public string dialog_no_action;
  public GameObject dialog_face;
  */

  public GameObject comm_ui;
  public bool show = false;
  public float show_scale = 0;
  public float show_speed = 1;
  public GameObject target_face;
  public TextMesh target_dialog;
  public TextMesh target_yes;
  public TextMesh target_no;
  public float text_speed = 20;
  private float text_dt = 0;
  private string text_character_cache = "";
  private string text_dialog_cache = "";

  // Use this for initialization
  void Start () {
    SetDialog(
      "Clooney Cat",
      "Howdy partner. We need you to deliver these palletes of medicine to Mars so all the good boys n' girls get better. Can ya'll handle that, boys?",
      "You Betcha!",
      "No Way!"
    );
  }

  // Update is called once per frame
  void Update () {

    target_dialog.text =
      text_character_cache+":\n"+
      ResolveTextSize(
        text_dialog_cache.Substring(
          0,
          Mathf.Min(text_dialog_cache.Length,(int)Mathf.Floor(text_dt*text_speed))),
        56
      );

    if(show){
      text_dt = text_dt + Time.deltaTime;
      show_scale = Mathf.Min(1,show_scale+Time.deltaTime*show_speed);
    } else {
      show_scale = Mathf.Max(0,show_scale-Time.deltaTime*show_speed);
    }
    comm_ui.transform.localScale = new Vector3(show_scale,show_scale,show_scale);
  }

  void SetDialog( string character, string text, string yes, string no){
    show = true;
    text_character_cache = character;
    text_dialog_cache = text;
    target_yes.text = yes;
    target_no.text = no;
    text_dt = 0;
  }


 // This function from: http://answers.unity3d.com/answers/232939/view.html
 // Wrap text by line height
 private string ResolveTextSize(string input, int lineLength){
   // Split string by char " "
   string[] words = input.Split(" "[0]);
   // Prepare result
   string result = "";
   // Temp line string
   string line = "";
   // for each all words        
   foreach(string s in words){
     // Append current word into line
     string temp = line + " " + s;
     // If line length is bigger than lineLength
     if(temp.Length > lineLength){
       // Append current line into result
       result += line + "\n";
       // Remain word append into new line
       line = s;
     }
     // Append current word into current line
     else {
       line = temp;
     }
   }
    // Append last line into result
    result += line;
    // Remove first " " char
    return result.Substring(1,result.Length-1);
 }

}
