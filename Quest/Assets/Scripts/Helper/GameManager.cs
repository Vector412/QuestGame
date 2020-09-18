using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] public GameObject playerPrefab;
    [SerializeField] GameObject spawner;
   
    void Start()
    {
        Vector3 pos = spawner.transform.position;
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
        Debug.Log(playerPrefab.name);
    }



    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
        Debug.Log(2);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
      
        Debug.LogFormat("Plaer {0} entered room", newPlayer.ActorNumber);
    }

    public void Leave()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            OnLeftRoom();
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.LogFormat("Plaer {0} left room.", otherPlayer.NickName);
        if (PhotonNetwork.IsMasterClient)
        {
            OnLeftRoom();
        }
    }





}


