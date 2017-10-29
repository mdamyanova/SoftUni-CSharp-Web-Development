using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour 
{
    public CustomButton button;

    void Start()
    {
        if (button != null)
        {
            button.clickParams.param0 = 0;
            button.clickParams.param1 = 1;
            button.clickParams.param2 = 2;
            button.clickAction = ButtonPressed;
        }
    }

    void ButtonPressed(ClickParams prm)
    {
        Debug.Log(string .Format("ButtonPressed with params : {0} , {1}, {2} ", prm.param0, prm.param1, prm.param2));
    }
}
