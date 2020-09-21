using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{

    SaveLoad playerposData;

    private void Start()
    {
        playerposData = FindObjectOfType<SaveLoad>();
    }
    public void Exit()
    {
        playerposData.PlayerposSave();
        SceneManager.LoadScene(2);
    }


}
