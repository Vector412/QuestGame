using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject window;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad")==1)
        {
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;
            float pZ = player.transform.position.z;
            float rY = player.transform.localRotation.y;
            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");
            pZ = PlayerPrefs.GetFloat("p_z");
            rY = PlayerPrefs.GetFloat("r_y");
            player.transform.position = new Vector3(pX, pY, pZ);
            player.transform.localRotation = Quaternion.Euler(0f, rY, 0f);
            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
     

    }
    public void PlayerposSave()
    {
        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.SetFloat("p_y", player.transform.position.y);
        PlayerPrefs.SetFloat("p_z", player.transform.position.z);
        PlayerPrefs.SetFloat("r_y", player.transform.localRotation.y);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }

    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
}
