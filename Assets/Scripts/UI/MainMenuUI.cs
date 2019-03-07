using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject panelIntro;
    


    public void OnEndBtnDown()
    {
        Application.Quit();
    }

    public void OnStartGame(string sceneName)
    {
        SceneManager.LoadScene("introduction");
    }


}
