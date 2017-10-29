using UnityEngine;
using System.Collections;

public class CollisionDetection2D : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D coll)
	{
		
		Debug.Log("OnTriggerEnter2D : " + coll.name);
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		Debug.Log("OnTriggerExit2D : " + coll.name);
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		Debug.Log("OnTriggerStay2D : " + coll.name);
	}


	void OnCollisionStay2D(Collision2D coll)
	{
		Debug.Log("OnCollisionStay2D : " + coll.collider.name);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log("OnCollisionEnter2D : " + coll.collider.name);
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		Debug.Log("OnCollisionExit2D : " + coll.collider.name);
	}


}
