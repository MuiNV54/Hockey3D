using UnityEngine;
using System.Collections;

public class PuckController : MonoBehaviour {

	public GameObject PlayerMallet;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 vector_diff = gameObject.transform.position - PlayerMallet.transform.position;
		if (vector_diff.magnitude <
		    (gameObject.transform.localScale.x + PlayerMallet.gameObject.transform.localScale.x)/2)
			rigidbody.AddForce((vector_diff/vector_diff.magnitude)*300);
	}
	
//	void OnCollisionEnter(Collision col) {
//		if( col.gameObject.name == "Mallet_player")
//		{
//			Vector3 vector_diff = gameObject.transform.position - PlayerMallet.transform.position;
//			rigidbody.AddForce((vector_diff/vector_diff.magnitude)*500);
//		}
//	}

}
