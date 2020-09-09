using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField]
    public GameObject optionScreen;
    [SerializeField]
    public GameObject menuScreen;


    public void Options()
    {
        menuScreen.SetActive(false);
        optionScreen.SetActive(true);
    }

    public void Back()
    {
        menuScreen.SetActive(true);
        optionScreen.SetActive(false);
    }

    public void Continue()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
