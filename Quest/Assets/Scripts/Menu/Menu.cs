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
        SceneManager.LoadScene(3);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");
        SceneManager.LoadScene(3);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    
}
