using UnityEngine;
using System.Collections;

public class PusherController : MonoBehaviour 
{
	public bool PusherMovedEnabled = false;
	public bool inMovableArea = true;
	public bool inTouchWithRail = false;

	void FixedUpdate () 
	{
		ControlPusher ();
	}

//	void OnTriggerEnter(Collider other)
//	{
//		if (other.tag == "Rail")
//		{
//			Debug.Log(transform.position.z);
//		}
//	}

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

//		SetMovableArea (hit.point);
		UpdatePosition(hit.point);
	}

	void UpdatePosition(Vector3 point)
	{
		if (PusherMovedEnabled)
		{
			if (Mathf.Abs(point.x) < 12)
			{
				if ((point.z <0) && (point.z > -30))
				{
					transform.position = new Vector3(point.x, transform.position.y, point.z);
				}
				else
				{
					transform.position = new Vector3(point.x, transform.position.y, transform.position.z);
				}
			}
			else if ((point.z <0) && (point.z > -30))
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, point.z);
			}

			rigidbody.useGravity = true;
			rigidbody.isKinematic = false;
		}
		else
		{
			rigidbody.useGravity = false;
			transform.position = new Vector3(transform.position.x, 8, transform.position.z);
			rigidbody.isKinematic = true;
		}
	}
}
