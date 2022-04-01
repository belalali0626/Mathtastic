using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerHandler : MonoBehaviourPunCallbacks
{
    public int index;
    public void Leave()
    {
        Time.timeScale = 1;
        PhotonNetwork.Disconnect();
    }

    public void DisconnectPlayer()
    {
        StartCoroutine(DiscAndLoad());
    }
    
    public void LeaveLobby()
    {
        StartCoroutine(QuitGame());

    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(index);
        base.OnLeftRoom();
    }


    IEnumerator DiscAndLoad()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();

        while (PhotonNetwork.InRoom)
            yield return null;
        PhotonNetwork.LoadLevel(0);
        Destroy(GameObject.Find("DontDestroyOnLoad"));
        Destroy(GameObject.Find("RoomManager"));


    }

    IEnumerator QuitGame()
    {
        PhotonNetwork.LeaveRoom();
        while (PhotonNetwork.InRoom)
            yield return null;
        Destroy(GameObject.Find("DontDestroyOnLoad"));
        Destroy(GameObject.Find("RoomManager"));
        PhotonNetwork.LoadLevel(index);


    }


}
