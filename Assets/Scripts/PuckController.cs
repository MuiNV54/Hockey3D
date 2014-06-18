using UnityEngine;
using System.Collections;

public class PuckController : MonoBehaviour {

	public GameObject PlayerMallet;
	public GameObject AIMallet;

	private float playerMalletDistance;
	private float AIMalletDistance;
	private Vector3 vectorPlayerDiff;
	private Vector3 vectorAIDiff;

	private Vector3 startPosition;

	void Start () 
	{
		startPosition = transform.position;
		playerMalletDistance = (gameObject.transform.localScale.x + PlayerMallet.gameObject.transform.localScale.x) / 2;
		AIMalletDistance = (gameObject.transform.localScale.x + AIMallet.gameObject.transform.localScale.x) / 2;
	}
	
	void FixedUpdate () 
	{
		vectorPlayerDiff = gameObject.transform.position - PlayerMallet.transform.position;
		vectorAIDiff = transform.position - AIMallet.transform.position;

		if (vectorPlayerDiff.magnitude < playerMalletDistance)
			rigidbody.AddForce((vectorPlayerDiff/vectorPlayerDiff.magnitude)*1000);

		if (vectorAIDiff.magnitude < AIMalletDistance)
			rigidbody.AddForce((vectorAIDiff/vectorAIDiff.magnitude)*1000);
	}

	void Update()
	{
//		Debug.Log (rigidbody.velocity);
	}

//	void OnCollisionEnter(Collision other)
//	{
//		if (other.gameObject.tag == "Mallet")
//		{
//			Vector3 vectorDiff = transform.position - other.transform.position;
//			rigidbody.AddForce(vectorDiff/vectorDiff.magnitude * 2000);
//		}
//	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Goal")
		{
			rigidbody.velocity = Vector3.zero;
			Vector3 startPointDiff = PlayerMallet.transform.position - startPosition;

			if (startPointDiff.magnitude < playerMalletDistance)
			{	
				transform.position = PlayerMallet.transform.position + new Vector3(0, 0, playerMalletDistance);
			}
			else
			{
				transform.position = startPosition;
			}
		}
	}
}
