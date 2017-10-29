using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorScript : MonoBehaviour 
{
    [MenuItem ("GameObject/Get Names of Selection")]
    static void MenuAddChild()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach (GameObject go in selectedObjects)
        {
            Debug.Log("Object name is : " + go.name);
        }
 
    }
 
    [MenuItem ("Custom Tools/Move Object")]
    static void MoveObject()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach (GameObject go in selectedObjects)
        {
            go.transform.Translate(1f, 0f, 0f);
        }
 
    }

    [MenuItem("GameObject/MyMenu/Do Something", false, 0)]
    static void ContextMenuItem()
    {
        Debug.Log("ContextMenuItem");
    }

}
