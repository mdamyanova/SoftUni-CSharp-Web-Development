using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    
    float resetCoordinate_Z = -20.44f;
    float speed = 10f;

	// Update is called once per frame
	void Update () 
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);

        if (transform.position.z < resetCoordinate_Z)
        {
            gameObject.SetActive(false);
        }
	}


}
