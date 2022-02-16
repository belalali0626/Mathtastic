using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{

    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    void Start()
    {
        Debug.Log("Connected To Master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        menuManager.Instance.OpenMenu("ms");
        menuManager.Instance.OpenMenu("logo");


        Debug.Log("Joined Lobby");
    }
    
    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }

        PhotonNetwork.CreateRoom(roomNameInputField.text);

        menuManager.Instance.OpenMenu("loading");

        Debug.Log("HELLO111");
    }

    public override void OnJoinedRoom()
    {
        menuManager.Instance.OpenMenu("room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Failed to create a room: " + message;
        menuManager.Instance.OpenMenu("error");
    }
}
