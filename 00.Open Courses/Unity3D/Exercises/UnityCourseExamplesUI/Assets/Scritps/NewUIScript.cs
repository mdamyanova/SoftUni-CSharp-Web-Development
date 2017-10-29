using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NewUIScript : MonoBehaviour 
{
    public RectTransform guiElementToMove;
    public Slider filledSlider;
    public Toggle toggle;
    public RectTransform mainContainer;
    public RectTransform parentObject;
    public Button guiStuff;
    public Button backBtn;
    private Text toggleLabel;
    
    private void Start()
    {
        if (toggle == null)
        {
            return;
        }

        toggleLabel = toggle.GetComponentInChildren<Text>();

        if (toggleLabel == null)
        {
            Debug.Log("Shit! something is wrong check the Text component in Toggle");
        }

        toggle.isOn = false;
        toggle.onValueChanged.AddListener(OnToggleValueChanged);

        if (mainContainer == null)
        {
            return;
        }


        if (guiStuff == null || mainContainer == null || backBtn == null)
        {
            return;
        }

        mainContainer.anchoredPosition += new Vector2(-Screen.width, 0f);

        //show first by drag and drop
        guiStuff.onClick.AddListener(MoveUI);
        backBtn.onClick.AddListener(() => { MoveContainer(new Vector2(-Screen.width, 0f), 0.3f, parentObject); });
    }

    private void FixedUpdate()
    {
        if (isMoving && rectToMove != null)
        {
            rectToMove.anchoredPosition = Vector2.MoveTowards(rectToMove.anchoredPosition, destinationPosition, moveStep);
            moveTime -= Time.fixedDeltaTime;

            if (moveTime <= 0f)
            {
                isMoving = false;
                rectToMove.anchoredPosition = destinationPosition;
                rectToMove = null;
            }
        }

        if (filledSlider == null)
            return;

        filledSlider.value += Time.fixedDeltaTime * 2;
    }

    float lastSliderValue;
    public void MoveElement(float sliderValue)
    {
        if (guiElementToMove == null || filledSlider == null || toggle == null)
        {
            return;
        }

        float increment = 0;
        if (lastSliderValue != sliderValue)
        {
            increment = (sliderValue - lastSliderValue) * 2f;
            lastSliderValue = sliderValue;
            guiElementToMove.anchoredPosition += new Vector2(increment, 0f);

            filledSlider.value = lastSliderValue;

            if (sliderValue >= 50)
            {
                toggle.isOn = true;
            }
            else
            {
                toggle.isOn = false;
            }
        }

    }

    public void OnToggleValueChanged(bool toggleValue)
    {
        Debug.Log("toggleValue : " + toggleValue);

        toggleLabel.text = System.Convert.ToString(toggleValue);
    }

    public void OnTextFieldSubmit(string textFieldValue)
    {
        int value;

        if (!int.TryParse(textFieldValue, out value))
            return;
		Debug.Log ("textfield value : " + textFieldValue);
        
		filledSlider.value = Mathf.Clamp (value, 0, 100);
	}
	
    float moveStep;
    float moveTime;
    RectTransform rectToMove;
    Vector2 destinationPosition;
    bool isMoving;
    public void MoveContainer(Vector2 moveIncrement, float time, RectTransform rectToMove)
    {
        Debug.Log("MoveContainer");
        this.rectToMove = rectToMove;
        destinationPosition = rectToMove.anchoredPosition + moveIncrement;
        moveStep = Time.fixedDeltaTime * Vector2.Distance(rectToMove.anchoredPosition, destinationPosition) / time;
        moveTime = time;
        isMoving = true;
    }

    public void MoveUI()
	{
		MoveContainer(new Vector2(Screen.width, 0f), 0.3f, parentObject);
	}
}
