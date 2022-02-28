using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    PhotonView view;

    [Header("Winner Conditions")]
    public string enemyTag;
    public int p1_Score;
    public int p2_Score;



    private void Update()
    {

        WinCheck();

        view = GetComponent<PhotonView>();

        if (p1_Score == 1)
        {
            if (view.IsMine)
            {
                Win();
            }

            if(!view.IsMine)
            {
                Loss();
            }
            
        }

    }

    void WinCheck()

    {
        GameObject Player = this.gameObject;
        Score PlayerScore = Player.GetComponent<Score>();

        p1_Score = PlayerScore.p_Score;


        GameObject EnemyPlayer = GameObject.FindGameObjectWithTag(enemyTag);
        Score EnemyScore = EnemyPlayer.GetComponent<Score>();

        p2_Score = EnemyScore.p_Score;


    }

    void Win()
    {
        GameManager.instance.Winner = true;
    }
    void Loss()
    {
        GameManager.instance.Loser = true;
    }




}
