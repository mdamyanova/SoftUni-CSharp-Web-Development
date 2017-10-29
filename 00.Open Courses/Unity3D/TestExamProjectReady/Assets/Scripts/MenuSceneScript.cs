using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuSceneScript : MonoBehaviour 
{
    public void OnPlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
