using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject player1;
    public  GameObject player2;

    [Header("Text Components")]
    public int p1_score;
    public int p2_score;

    [Header("Winner Conditions")]
    bool Win = true;
    bool Loss = true;
    [PunRPC]void recieveP1(int Score)
    {
        p1_score += Score/2;
    }
    [PunRPC] void recieveP2(int score)
    {
        p2_score += score/2;

    }

    void Update()
    {
/*        player1 = GameObject.FindGameObjectWithTag("playerAB1");
        player2 = GameObject.FindGameObjectWithTag("playerAB2");
        PhotonView target1 = player1.GetComponent<PhotonView>();
        PhotonView target2 = player2.GetComponent<PhotonView>();



      if (p1_score > 5)
      {
            target1.RPC("WinCheck", RpcTarget.All, Win);
            target2.RPC("LossCheck", RpcTarget.All, Loss);

      }

      else if (p2_score > 5)
      {
            target2.RPC("WinCheck", RpcTarget.All, Win);
            target1.RPC("LossCheck", RpcTarget.All, Loss);
        }*/

    }

}
