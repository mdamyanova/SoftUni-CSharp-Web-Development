using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour 
{

	public float startPosition;
	public float endPosition;
	public float speed = 3f;
	
	// Update is called once per frame
	void Update () 
	{

		if(transform.position.x < endPosition)
		{
			transform.position = new Vector2(startPosition, transform.position.y);
		}
		else
		{
			transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
		}
	}
}


