using UnityEngine;
using System.Collections;

public class MalletBorder : MonoBehaviour 
{
	public float LeftBorder = -17;
	public float RightBorder = 17;
	public float BotBorder = 0;
	public float TopBorder = 28.4f;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		SetBorder ();
	}

	void SetBorder()
	{
		if (transform.position.z > TopBorder)
			transform.position = new Vector3(transform.position.x, transform.position.y, TopBorder);
		
		if (transform.position.z < BotBorder)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, BotBorder);
		}
		
		if (transform.position.x < LeftBorder)
			transform.position = new Vector3(LeftBorder ,transform.position.y, transform.position.z);
		
		if (transform.position.x > RightBorder)
			transform.position = new Vector3(RightBorder ,transform.position.y, transform.position.z);
	}
}
