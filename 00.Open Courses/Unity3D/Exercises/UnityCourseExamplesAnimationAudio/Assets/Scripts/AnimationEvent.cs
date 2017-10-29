using UnityEngine;
using System.Collections;

public class AnimationEvent : MonoBehaviour 
{
    public void AnimationEventMethod()
    {
        Debug.Log("Do your wicked stuff here");
    }

    public void ImportedAnimationEventMethod(string stringParamater)
    {
        Debug.Log("ImportedAnimationEventMethod : " + stringParamater);
    }

    
}
