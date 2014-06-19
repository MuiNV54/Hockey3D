using UnityEngine;
using System.Collections;

public class PusherController : MonoBehaviour 
{
	public bool PusherMovedEnabled = false;
	public GameObject Puck;

	public float LeftBorder = -10;
	public float RightBorder = 10;
	public float TopBorder = 0;
	public float BotBorer = -28.4f;

	void FixedUpdate () 
	{
		SetBorder ();
		ControlPusher ();
	}

	void ControlPusher()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			Debug.DrawLine(ray.origin, hit.point);
			if (Input.GetMouseButtonDown(0))
			{
				PusherMovedEnabled = true;
			}
			
			if (Input.GetMouseButtonUp(0) && PusherMovedEnabled)
			{
				PusherMovedEnabled = false;
			}
		}

		UpdatePosition(hit.point);
	}

	void UpdatePosition(Vector3 point)
	{
		if (PusherMovedEnabled)
		{
			Vector3 ForceControll = point - transform.position;
			ForceControll.y = 0;

			rigidbody.AddForce(ForceControll*5000);
		}
	}

	void SetBorder()
	{
		if (transform.position.z > TopBorder)
			transform.position = new Vector3(transform.position.x, transform.position.y, TopBorder);
		
		if (transform.position.z < BotBorer)
			transform.position = new Vector3(transform.position.x, transform.position.y, BotBorer);
		
		if (transform.position.x < LeftBorder)
			transform.position = new Vector3(LeftBorder ,transform.position.y, transform.position.z);
		
		if (transform.position.x > RightBorder)
			transform.position = new Vector3(RightBorder ,transform.position.y, transform.position.z);
	}
}
