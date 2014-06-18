using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour 
{
	private Vector3 initPosition;
	public GameObject Puck;

	void Start () 
	{
		initPosition = transform.position;
	}
	
	void Update () 
	{
		transform.LookAt (Puck.transform.position);
		transform.position = Vector3.Lerp (transform.position, initPosition, 5 * Time.deltaTime);
		AIBehavior ();
	}

	void AIBehavior()
	{
		if (Puck.transform.position.z >= 0)
		{
			rigidbody.AddForce(transform.forward * 150000);
			Debug.Log("ABC123");
		}
	}
}
