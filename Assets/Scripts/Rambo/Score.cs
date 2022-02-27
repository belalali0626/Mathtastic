using System.Collections;
using System.Collections.Generic;
using TMPro;
using Photon.Pun;
using UnityEngine;

public class Score : MonoBehaviour
{

    [Header("Variables")]
    public int p_Score = 0;
    public string PlayerScoreTag;

    [Header("What Player Is It?")]
    public string MethodName;


    [Header("Text Components")]
    public TMP_Text p_Text;
    public GameObject text;
    public GameObject ScoreManager;

    void Awake()
    {
        ScoreManager = GameObject.FindGameObjectWithTag("ScoreManager");

        text = GameObject.FindGameObjectWithTag(PlayerScoreTag);
        p_Text = text.GetComponent<TMP_Text>();
    }

    [PunRPC]void giveScore(int score)
    {
        p_Score += score;
        updateScore();

        PhotonView target = ScoreManager.GetComponent<PhotonView>();
        target.RPC(MethodName, RpcTarget.All, score);


    }

    void updateScore()
    {
        p_Text.text = p_Score.ToString();
    }
}
