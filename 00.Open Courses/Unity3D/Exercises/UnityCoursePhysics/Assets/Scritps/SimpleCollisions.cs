using UnityEngine;
using System.Collections;

public class SimpleCollisions : MonoBehaviour 
{

	void OnCollisionEnter(Collision collision)
	{
        //foreach (ContactPoint point in collision.contacts)
        //{
        //    Debug.Log("point : " + point.point);
        //}

		Debug.Log ("OnCollisionEnter : " + collision.gameObject.name);
	}

	void OnCollisionExit(Collision collision)
	{
        
		Debug.Log ("OnCollisionExit : " + collision.gameObject.name);
	}

	void OnCollisionStay(Collision collision)
	{
		Debug.Log ("OnCollisionStay : " + collision.gameObject.name);
	}

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log ("OnTriggerEnter : " + collider.gameObject.name);
	}

	void OnTriggerExit(Collider collider)
	{
		Debug.Log ("OnTriggerExit : " + collider.gameObject.name);
	}

	void OnTriggerStay(Collider collider)
	{
		Debug.Log ("OnTriggerStay : " + collider.gameObject.name);
	}


}
