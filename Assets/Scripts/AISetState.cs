using UnityEngine;
using System.Collections;

public enum AIState 
{
	Idle,
	Backward,
	Action
}

public class AISetState : MonoBehaviour 
{
	public Vector3 initPosition;

	public GameObject Puck;
	public AIState aiState = AIState.Idle;
	private Puck puckController;

	public bool backwardActive = false;
	public float backwardTimer = 0;
	public float resetBackwardTimer = 1.0f;

	void Start () 
	{
		initPosition = new Vector3(0, 5.48f, 27);
	}
	
	void Update () 
	{
		AIBehavior ();
	}

	void AIBehavior()
	{
		transform.LookAt (Puck.transform.position);
		
		if (((transform.position.z < (Puck.transform.position.z - 1.2f)) && Puck.transform.position.z <= 29))
		{
			backwardActive = true;
		}
		
		if (backwardActive)
		{
			aiState = AIState.Backward;
		}
		
		if (backwardActive)
		{
			backwardTimer -= Time.deltaTime;
			
			if (backwardTimer <= 0)
			{
				backwardActive = false;
				backwardTimer = resetBackwardTimer;
			}
		}

		if ((Puck.transform.position.z >= 0) && !backwardActive)
		{
			puckController = Puck.GetComponent<Puck>();

			if (!puckController.deadActive)
			{
				aiState = AIState.Action;
			}
		}

		if (Puck.transform.position.z < 0)
		{
			Vector3 relativePosition = transform.position - initPosition;

			if (relativePosition.magnitude < 0.1f && rigidbody.velocity.magnitude < 0.1f)
				aiState = AIState.Idle;
		}
	}
}
