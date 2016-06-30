using UnityEngine;
using System.Collections;

public class ProceduralMenu : MonoBehaviour {
	public GameObject[] MenuItems;
	public string[] MenuScenes;
	
	public Vector3 Origin;
	public Vector3 Distance;
	public Vector3 Rotation;
	
	public Material DefaultMaterial;
	public Material SelectedMaterial;
	
	
	
	bool oldPressed = false;
	int SelectedItem = 0;
	
	// Use this for initialization
	void Start () {
		for (int i =0; i < MenuItems.Length; i++) {
			MenuItems[i] = (GameObject) Instantiate(MenuItems[i],Origin + Distance * i - Distance,Quaternion.Euler(Rotation));
		}
			refreshMenu();
		}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetAxis("Pitch Joystick") > 0 || Input.GetAxis("Pitch KB&M") > 0){
				if (oldPressed == false) {
					SelectedItem -= 1;
					if (SelectedItem < 0) { SelectedItem = MenuItems.Length - 1;}
					refreshMenu();
				}
				oldPressed = true;
			} else if (Input.GetAxis("Pitch Joystick") < 0 || Input.GetAxis("Pitch KB&M") < 0 ){
				if (oldPressed == false) {
					SelectedItem += 1;
					if (SelectedItem > MenuItems.Length - 1) { SelectedItem = 0;}
					refreshMenu();
				}
				oldPressed = true;
			} else {
				oldPressed = false;
			}
			
			if (Input.GetButton("Submit")) {
				if (MenuScenes[SelectedItem] == "quit")
				{
          Debug.Log("Goodbye xbox cowboy");
					Application.Quit();
				} else {
					Application.LoadLevel(MenuScenes[SelectedItem]);
				}
			}
	}
	
	void refreshMenu() {
		for (int i =0; i < MenuItems.Length; i++) {
			MenuItems[i].GetComponent<Renderer>().material = DefaultMaterial;
		}
		MenuItems[SelectedItem].GetComponent<Renderer>().material = SelectedMaterial;
	}
}
