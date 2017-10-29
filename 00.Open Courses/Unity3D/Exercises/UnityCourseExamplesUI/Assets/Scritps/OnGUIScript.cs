using UnityEngine;
using System.Collections;

public class OnGUIScript : MonoBehaviour 
{
    public Texture2D icon;
    string textField = string.Empty;
    string textArea = string.Empty;
    bool checkBox = true;
    float sliderValue;
    Rect windowRect = new Rect(10, 390, 160, 50);

    public GUIStyle myStyle;
    public GUISkin mySkin;

    //Works like Update method but it's called a bit more often compared to Update
    void OnGUI()
    {
        //Debug.Log("OnGUI");

        GUI.Box(new Rect(10, 10, 120, 120), "Menu Box");

        if (GUI.Button(new Rect(20, 40, 100, 20), "Button One"))
        {
            Debug.Log("Button One clicked");
        }

        if (Time.time % 2 < 1)
        {
            if (GUI.Button(new Rect(20, 70, 100, 20), "Blink button"))
            {
                Debug.Log("Blinking button clicked");
            }
        }

        if (GUI.Button(new Rect(20, 100, 100, 20), icon))
        {
            print("icon is clicked");
        }

        GUI.Label(new Rect(10, Screen.height - 20, 100, 50), "This is label");

        GUI.Box(new Rect(10, 150, 120, 50), new GUIContent("This is text", icon, "tooltip"));

        GUI.skin = mySkin;

        GUI.Label(new Rect(135, 150, 120, 20), GUI.tooltip);

        textField = GUI.TextField(new Rect(10, 210, 120, 20), textField);

        textArea = GUI.TextArea(new Rect(10, 250, 120, 50), textArea);

        checkBox = GUI.Toggle(new Rect(10, 310, 120, 30), checkBox, "CheckBox");

        sliderValue = GUI.HorizontalSlider(new Rect(10, 350, 120, 30), sliderValue, 0.0f, 10.0f);

        windowRect = GUI.Window(0, windowRect, WindowUpdateMethod, "My Window");

        GUI.Button(new Rect(10, 460, 160, 20), "I am a Custom Button", myStyle);

        GUIStyle style = GUI.skin.GetStyle("label");

        style.fontSize = (int)(20.0f + 10.0f * Mathf.Sin(Time.time));

        GUI.Label(new Rect(10, 490, 260, 80), "Changing font!");

        GUI.Label(new Rect(10, 520, 400, 80), "Changing font Two!");
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    void WindowUpdateMethod(int windowID)
    {
        //Debug.Log("WindowUpdateMethod");
    }
}
