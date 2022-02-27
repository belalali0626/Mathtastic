using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Text Components")]
    public TMP_Text p1;
    public TMP_Text p2;

    int p1_score;
    int p2_score;


    void Update()
    {
        p1_score = Int32.Parse(p1.name);
        p2_score = Int32.Parse(p2.name);

        if (p1_score > 5 )
        {

        }

        else if (p2_score > 5)
        {

        }

    }
    void Winner()
    {

    }
}
