using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public GameObject menuScreen;


    public void Options()
    {
        menuScreen.SetActive(false);

    }

    public void Back()
    {
        menuScreen.SetActive(true);
   }

    public void Continue()
    {
        SaveLoad.Instance.IsNewGame = !(PlayerPrefs.GetString("IsEnd", "") == "");
        SceneManager.LoadScene(3);
    }

    public void NewGame()
    {
        SaveLoad.Instance.IsNewGame = true;
        SceneManager.LoadScene(3);
    }
    public void Multiplayer()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
