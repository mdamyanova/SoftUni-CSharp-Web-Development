using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour 
{
	public float hitForce = 50;
	public float explosionRadius = 10;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 20f))
			{
				Debug.Log ("hit : " + hit.collider.name);
			}
		}
        
	}
}
