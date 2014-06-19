using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void OnMouseEnter(){
		gameObject.renderer.material.color = Color.yellow;
	}
	void OnMouseExit(){
		gameObject.renderer.material.color = Color.red;
	}
	void OnMouseDown(){
		switch (gameObject.name) {
		case "Play_text":
			Application.LoadLevel("Difficulty");
			break;
		case "Exit_text" :
			Application.Quit();
			break;
		}
	}
}
