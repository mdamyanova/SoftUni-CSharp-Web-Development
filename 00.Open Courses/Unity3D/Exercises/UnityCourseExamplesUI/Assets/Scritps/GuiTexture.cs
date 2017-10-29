using UnityEngine;
using System.Collections;

public class GuiTexture : MonoBehaviour 
{
    GUITexture attachedTexture;
    void Start()
    {
        attachedTexture = GetComponent<GUITexture>();
    }
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0) && attachedTexture.HitTest(Input.mousePosition))
        {
            Debug.Log("Mouse over texture");
        }
	}
}
