using UnityEngine;
using System.Collections;

public class PlayerMalletController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 var = Vector3.zero;
		var.x = Input.GetAxis("Horizontal");
		var.z = Input.GetAxis("Vertical");
		transform.Translate(var*Time.deltaTime*20.0f);
		                
	}
}
