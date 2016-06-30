using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

  public GameObject dialog_ui;
  public bool show = false;
  private float show_scale = 0;
  public float show_speed = 1;

  public GameObject target_face;
  public TextMesh target_dialog;
  public TextMesh target_yes;
  public TextMesh target_no;
  public float text_speed = 20;
  private float text_dt = 0;
  private string text_character_cache = "";
  private string text_dialog_cache = "";

  public float health = 0;
  public GameObject health_bar;
  public TextMesh health_bar_text;
  private float health_max_scale;

  public float shield = 0;
  public GameObject shield_bar;
  public TextMesh shield_bar_text;
  private float shield_max_scale;

  public float energy = 0;
  public GameObject energy_bar;
  public TextMesh energy_bar_text;

  // Use this for initialization
  void Start () {
    SetDialog(
      "Clooney Cat",
      "Howdy partner. We need you to deliver these palletes of medicine to Mars so all the good boys n' girls get better. Can ya'll handle that, boys?",
      "You Betcha!",
      "No Way!"
    );
    shield_max_scale = shield_bar.transform.localScale.x;
    health_max_scale = health_bar.transform.localScale.x;
  }

  // Update is called once per frame
  void Update () {

    health_bar_text.text = "Integrity: "+Mathf.Floor(health*100)+"%";
    //health = Mathf.Min(1,health+Time.deltaTime);
    health_bar.transform.localScale = new Vector3(health*health_max_scale,health*health_max_scale,health_max_scale);

    shield_bar_text.text = "Shield: "+Mathf.Floor(shield*100)+"%";
    shield = Mathf.Min(1,shield+Time.deltaTime/8);
    shield_bar.transform.localScale = new Vector3(shield*shield_max_scale,shield*shield_max_scale,shield_max_scale);

    energy_bar_text.text = "Station: "+Mathf.Floor(energy*100)+"%";
    energy_bar.transform.localScale = new Vector3(energy*5,1,0.1F);
    //energy = Mathf.Min(1,energy+Time.deltaTime);

    target_dialog.text =
      text_character_cache+":\n"+
      ResolveTextSize(
        text_dialog_cache.Substring(
          0,
          Mathf.Min(text_dialog_cache.Length,(int)Mathf.Floor(text_dt*text_speed))),
        56
      );

    if(text_dialog_cache.Length + 25 < (int)Mathf.Floor(text_dt*text_speed)){
      show = false;
    }

    if(show){
      text_dt = text_dt + Time.deltaTime;
      show_scale = Mathf.Min(1,show_scale+Time.deltaTime*show_speed);
    } else {
      show_scale = Mathf.Max(0,show_scale-Time.deltaTime*show_speed);
    }
    dialog_ui.transform.localScale = new Vector3(show_scale,show_scale,show_scale);
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
