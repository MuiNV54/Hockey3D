using UnityEngine;
using System.Collections;

public class DifficultyScript : MonoBehaviour {

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
		case "Easy_text":
			Application.LoadLevel("Scene1");
			break;
		case "Hard_text" :
			Application.LoadLevel("Scene");
			break;
		case "Back_text" :
			Application.LoadLevel("Menu");
			break;
		}
	}
}
