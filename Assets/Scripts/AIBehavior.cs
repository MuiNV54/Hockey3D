using UnityEngine;
using System.Collections;

public class AIBehavior : MonoBehaviour 
{
	private AISetState aiSetState;

	private bool adjustActive = false;
	public float adjustTimer = .3f;
	private float resetAdjustTimer = 0.8f;

	public float adjustPositionX;
	public float adjustPositionZ;
	private Vector3 newPosition;

	void Start () 
	{
		aiSetState = GetComponent<AISetState> ();
		newPosition = aiSetState.initPosition;
	}
	
	void Update () 
	{
		AIAction ();
	}

	void AIAction()
	{
		switch (aiSetState.aiState)
		{
		case AIState.Idle:
			adjustTimer -= Time.deltaTime;
			if (adjustTimer <= 0)
			{
				AdjustPosition();
				adjustTimer = resetAdjustTimer;
			}

			transform.position = Vector3.Lerp(transform.position, newPosition, 5 * Time.deltaTime);
			break;
		
		case AIState.Action:
			rigidbody.AddForce(transform.forward * 300000);
			break;

		case AIState.Backward:
			transform.position = Vector3.Lerp (transform.position, aiSetState.initPosition, 3 * Time.deltaTime);
			break;
		}
	}

	void AdjustPosition()
	{
		adjustPositionZ = Random.Range(-8.0f, 0.0f);
		adjustPositionX = Random.Range(-8.0f, 8.0f);
		
		newPosition = new Vector3(aiSetState.initPosition.x + adjustPositionX, aiSetState.initPosition.y,
		                          aiSetState.initPosition.z + adjustPositionZ);
//		transform.position = newPosition;
	}
}
