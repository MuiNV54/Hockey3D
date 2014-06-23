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
		Vector3 currentPos = transform.position;
		if (currentPos.z > TopBorder)
		{
			currentPos.z = TopBorder;
		}
		
		if (currentPos.z < BotBorder)
		{
			currentPos.z = BotBorder;
		}
		
		if (currentPos.x < LeftBorder)
			currentPos.x = LeftBorder;

		if (currentPos.x > RightBorder)
			currentPos.x = RightBorder;

		transform.position = currentPos;
	}
}
