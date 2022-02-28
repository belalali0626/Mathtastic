using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerHandler : MonoBehaviourPunCallbacks
{
    public void Leave()
    {
        Time.timeScale = 1;
        PhotonNetwork.Disconnect();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(0);
    }

}
