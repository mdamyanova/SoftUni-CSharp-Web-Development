using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	Rigidbody2D attachedRigidbody;
	public float jumpForce = 5f;
	// Use this for initialization
	void Start () 
	{
		attachedRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
 	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(attachedRigidbody.gravityScale == 0)
			{
				attachedRigidbody.gravityScale = 2f;
			}

			attachedRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{	
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
