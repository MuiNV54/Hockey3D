using UnityEngine;
using System.Collections;

public class PuckController : MonoBehaviour {

	public GameObject PlayerMallet;
	public GameObject AIMallet;

	public bool deadActive = false;
	public float deadTimer = 1.0f;
	public float resetdeadTimer = 1.0f;

	public static int playerScore = 0;
	public static int AIScore = 0;

	private AISetState aiMovement;

	private float playerMalletDistance;
	private float AIMalletDistance;
	private Vector3 vectorPlayerDiff;
	private Vector3 vectorAIDiff;

	private Vector3 startPosition;

	void Start () 
	{
		startPosition = new Vector3 (0, 5.5f, -16);
		playerMalletDistance = (gameObject.transform.localScale.x + PlayerMallet.gameObject.transform.localScale.x) / 2;
		AIMalletDistance = (gameObject.transform.localScale.x + AIMallet.gameObject.transform.localScale.x) / 2;

		aiMovement = AIMallet.GetComponent<AISetState> ();
	}
	
	void FixedUpdate () 
	{
		vectorPlayerDiff = gameObject.transform.position - PlayerMallet.transform.position;
		vectorAIDiff = transform.position - AIMallet.transform.position;

		if (vectorPlayerDiff.magnitude < playerMalletDistance)
			rigidbody.AddForce((vectorPlayerDiff/vectorPlayerDiff.magnitude)*3000);

		if (vectorAIDiff.magnitude < AIMalletDistance)
		{
			rigidbody.AddForce((vectorAIDiff/vectorAIDiff.magnitude)*3000);
			if (!aiMovement.backwardActive)
			{
				aiMovement.backwardActive = true;
			}
		}
	}

	void Update()
	{
		if (deadActive)
		{
			deadTimer -= Time.deltaTime;

			if (deadTimer <= 0)
			{
				deadActive = false;
				ResetPosition();
				deadTimer = resetdeadTimer;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Goal")
		{
			deadActive = true;

			UpdateScore();
		}
	}

	void UpdateScore()
	{
		if (transform.position.z < 0)
			AIScore++;
		else
			playerScore++;

	}

	void ResetPosition()
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
