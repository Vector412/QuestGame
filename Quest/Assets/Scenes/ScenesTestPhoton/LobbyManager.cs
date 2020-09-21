using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text LogText;

    public int NumberPlayer { get; set; }


    void Start()
    {
        NumberPlayer = 0;
        Debug.Log(111);
        PhotonNetwork.NickName = "Player" + " " + Random.Range(1, 10);
        Log("Player is name is set to" + " " + PhotonNetwork.NickName);

        PhotonNetwork.AutomaticallySyncScene = true; // автопереключение сцены
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings(); // подключение к мастер серверу
        
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to master");
    }

    public void Log(string messages)
    {
        Debug.Log(messages);
        LogText.text += "\n";
        LogText.text += messages;
    }

    public void CreetRoom()
    {
            PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 5 });
      
            
    }
    public void JoinRoom()
    {
        NumberPlayer++;
        PhotonNetwork.JoinRandomRoom();

    }

    public override void OnJoinedRoom()
    {
        Log("Joined the room");
        PhotonNetwork.LoadLevel("MultiPlayer");
       
    }


   




}

