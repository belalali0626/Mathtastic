using System.Collections;
using System.Collections.Generic;
using TMPro;
using Photon.Pun;
using UnityEngine;

public class Score : MonoBehaviour
{

    [Header("Variables")]
    public int p_Score = 0;
    public string PlayerScore;

    [Header("Text Components")]
    public TMP_Text p_Text;
    public GameObject text;


    void Update()
    {
        text = GameObject.FindGameObjectWithTag(PlayerScore);
        p_Text = text.GetComponent<TMP_Text>();
        updateScore();
    }

    [PunRPC]void giveScore(int score)
    {
        p_Score += score;
    }

    void updateScore()
    {
        p_Text.text = p_Score.ToString();
        p_Text.name = p_Score.ToString();
    }
}
