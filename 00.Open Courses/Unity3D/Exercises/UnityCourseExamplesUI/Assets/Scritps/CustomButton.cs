using UnityEngine;
using System;
using System.Collections;

public class CustomButton : MonoBehaviour 
{
    bool isHovered;
    public ClickParams clickParams = new ClickParams();
    public Action<ClickParams> clickAction;

    void OnMouseEnter()
    {
        isHovered = true;
        //activate hover state
    }

    void OnMouseExit()
    {
        isHovered = false;
        //deactivate hover state
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isHovered)
        {
            if (clickAction != null)
            {
                clickAction(clickParams);
            }
            //activate clicked state
        }

        if (Input.GetMouseButtonUp(0) && isHovered)
        {
            //deactivate clicked state

            //call click method on mouse Up if you wish
        }
    }
}

public class ClickParams
{
    public object param0;
    public object param1;
    public object param2;
}
