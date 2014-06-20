using UnityEngine;
using System.Collections;

public class AIcontroller : MonoBehaviour {
	public enum FSMState
	{
		Attack,
		Backoff,
		Defense,
	}

	public GameObject Puck;
	public FSMState curState;
	public float LeftBorder = -10;
	public float RightBorder = 10;
	public float TopBorder = 0;
	public float BotBorder = -28.4f;
	public Vector3 GoalPos;

	private bool Attack_lockFlag = false; 
	private bool Back_lockFlag = false;
	private bool Collision_detected = false;
	// Use this for initialization
	void Start () {
		curState = FSMState.Backoff;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		FSMUpdate();
	}
	
	void FSMUpdate() {
		switch (curState) {
		case FSMState.Attack: 
			AttackUpdate();
			break;
		case FSMState.Backoff:
			BackoffUpdate();
			break;
		case FSMState.Defense:
			DefenseUpdate();
			break;
		}
	}

	// Under Construction
	void AttackUpdate(){
		Vector3 ObjPos = Vector3.zero;
		Vector3 ObjVel = Vector3.zero;
		// Attack Action
		if(!Attack_lockFlag)
		{
			ObjPos = Puck.transform.position;       // Save the Puck position
			ObjVel = Puck.rigidbody.velocity;       // Save the Puck velocity
			rigidbody.AddForce((ObjPos + ObjVel*10*Time.deltaTime - gameObject.transform.position)*50000);
			Attack_lockFlag = true;
		}

		if (Collision_detected || transform.position.z <0f || rigidbody.velocity.magnitude <0.5f || transform.position.z > 33f)
		{
			curState = FSMState.Backoff;
			Attack_lockFlag = false;
			Collision_detected = false;
		}


	}

//	void BackoffUpdate(){
//		if (!Back_lockFlag)
//		{
//			Vector3 Back_vector = GoalPos- gameObject.transform.position;
//			rigidbody.AddForce(Back_vector*10000);
//			Debug.Log(Back_vector);
//			Back_lockFlag = true;
//		}
//		if((transform.position-GoalPos).magnitude < 0.5f)
//		{
//			curState = FSMState.Defense;
//			Back_lockFlag = false;
//		}
//	}
	void BackoffUpdate(){

		transform.position = Vector3.Lerp(transform.position, GoalPos, 20*Time.deltaTime);
		if((transform.position-GoalPos).magnitude < 0.5f)
		{
			curState = FSMState.Defense;
		}
	}

	void DefenseUpdate(){
		float Xthreshold =5.5f;
		float PuckZthreshold = 0f;
		if (gameObject.transform.position.x > -Xthreshold)
		{
			if (gameObject.transform.position.x > Puck.transform.position.x)
				rigidbody.AddForce(-500f,0,0);
		}
		if (gameObject.transform.position.x < Xthreshold)
		{
			if (gameObject.transform.position.x < Puck.transform.position.x)
				rigidbody.AddForce(500f,0,0);
		}
		if (Puck.transform.position.z > PuckZthreshold)
			curState = FSMState.Attack;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Puck")
			Collision_detected = true;

	}

	void OnCollisionExit( Collision col)
	{
		if (col.gameObject.name == "Puck")
			Collision_detected = false;
	}
}
