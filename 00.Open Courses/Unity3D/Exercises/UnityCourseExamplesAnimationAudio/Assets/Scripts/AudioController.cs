using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    public AudioClip clipToPlay;

    public void PlayAudioClip()
    {
        Debug.Log("PlayAudioClip");
        GetComponent<AudioSource>().clip = clipToPlay;
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAudioClip();
        }
    }
}
