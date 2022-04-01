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

    [Header("Text Components")]
    public GameObject spawn1;
    public GameObject spawn2;

    [Header("Text Components")]
    public TMP_Text p_Text;
    public GameObject text;
    public GameObject ScoreManager;

    void Awake()
    {
        ScoreManager = GameObject.FindGameObjectWithTag("ScoreManager");

        text = GameObject.FindGameObjectWithTag(PlayerScoreTag);
        p_Text = text.GetComponent<TMP_Text>();

        spawn1 = GameObject.FindGameObjectWithTag("spawn1");
        spawn2 = GameObject.FindGameObjectWithTag("spawn2");

        GameObject player1 = GameObject.FindGameObjectWithTag("playerAB1");
        GameObject player2 = GameObject.FindGameObjectWithTag("playerAB2");

    }

    [PunRPC]void giveScore(int score)
    {
        p_Score += score;
        updateScore();
        FindObjectOfType<AudioManager>().Play("score");
        RespawnFromScore();

    }

    void RespawnFromScore()
    {
        if (gameObject.tag == "playerAB1")
        {
            gameObject.transform.position = spawn1.transform.position;
        }
        if (gameObject.tag == "playerAB2")
        {
            gameObject.transform.position = spawn2.transform.position;

        }
    }

    void updateScore()
    {
        p_Text.text = p_Score.ToString();
    }
}
