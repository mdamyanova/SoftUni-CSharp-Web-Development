using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    public GameObject playerDeadLbl;

    public Text scoreLbl;

    public void OnHomeClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }

    
    //3. Добавете бутон, който да рестартира нивото.
    public void OnResetLevelClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowDeadText()
    {
        this.playerDeadLbl.SetActive(true);
    }

    //2. Добавете бутон, който да нулира точките.
    public void OnClearScoreClicked()
    {
        PlayerPrefs.DeleteAll();
        FindObjectOfType<AirPlaneScript>().score = 0;
        this.scoreLbl.text = string.Format("Score : {0}", 0);
    }
}