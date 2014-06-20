using UnityEngine;
using System.Collections;

public class DisplayScore : MonoBehaviour 
{
	public int rows = 5;
	public int columns = 2;

	private Vector2 frameSize;
	private Vector2 frameOffset;
	private Vector2 framePosition;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (gameObject.name == "AIScore")
		{
			DefineScore (Puck.AIScore);
		}
		else
			DefineScore(Puck.playerScore);
	}

	void DefineScore(int score)
	{
		if (score == 0)
		{
			framePosition.x = 4;
			framePosition.y = 0;
		}
		else
		{
			if (score <= 5)
			{
				framePosition.y = 1;
				framePosition.x = score -1;
			}
			else
			{
				framePosition.y = 0;
				framePosition.x = score - 6;
			}
		}

		frameSize = new Vector2 (1.0f / rows, 1.0f / columns);
		frameOffset = new Vector2(framePosition.x / rows, framePosition.y / columns);
		
		renderer.material.SetTextureScale ("_MainTex", frameSize);
		renderer.material.SetTextureOffset ("_MainTex", frameOffset);
	}
}
