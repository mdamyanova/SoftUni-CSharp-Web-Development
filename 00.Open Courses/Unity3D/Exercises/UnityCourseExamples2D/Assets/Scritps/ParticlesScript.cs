using UnityEngine;
using System.Collections;

public class ParticlesScript : MonoBehaviour 
{
    ParticleSystem attachedParticle;

	// Use this for initialization
	void Start () 
    {
        attachedParticle = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (attachedParticle.isPlaying)
            {
                Debug.Log("Stop");
                attachedParticle.Stop();
            }
            else
            {
                Debug.Log("Play");
                attachedParticle.Play();
            }
            
        }
	
	}
}
