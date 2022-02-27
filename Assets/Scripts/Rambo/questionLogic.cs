using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class questionLogic : MonoBehaviour
{

    [Header("Script Values")]
    private int lowFirstValue = 1;
    private int highFirstValue = 10;
    public int firstValue;
    private int lowSecondValue = 1;
    private int highSecondValue = 10;
    public int SecondValue;
    public int finalValue1;
    public int finalValue2;
    public int finalValue3;
    [Header("Components")]
    public TMP_Text gameTxt;

    public string rightAnswer;

    [Header("Arrays")]
    float[] answers = new float[3];
    string[] questions = new string[3];
    public TMP_Text[] answersBox;
    private TMP_Text tempBox;

    void Start()
    {
        
        Question();
       

    }
    public void Question()
    {
        firstValue = Random.Range(lowFirstValue, highFirstValue);
        SecondValue = Random.Range(lowSecondValue, highSecondValue);


        for (int e = 1; e < 4; e++)
        {
            if (e == 1)
            {
                finalValue1 = firstValue + SecondValue;
                answers[0] = finalValue1;
                questions[0] = (firstValue + " + " + SecondValue);
            }
            if (e == 2)
            {
                finalValue2 = firstValue - SecondValue;
                answers[1] = finalValue2;
                questions[1] = (firstValue + " - " + SecondValue);
            }
            if (e == 3)
            {
                finalValue3 = firstValue * SecondValue;
                answers[2] = finalValue3;
                questions[2] = (firstValue + " x " + SecondValue);
            }

        }
        EndAnswer();
        shuffleAnswers();

    }

    public void EndAnswer()
    {
        float aQnswer = answers[Random.Range(0, answers.Length)];
        Debug.Log("the array is " + aQnswer);

        if (aQnswer == answers[0])
        {
            gameTxt.text = questions[0];
            rightAnswer = answers[0].ToString();

            Debug.Log("right answer = " + rightAnswer);
        }
        if (aQnswer == answers[1])
        {
            gameTxt.text = questions[1];
            rightAnswer = answers[1].ToString();
            Debug.Log("right answer = " + rightAnswer);

        }
        if (aQnswer == answers[2])
        {
            gameTxt.text = questions[2];
            rightAnswer = answers[2].ToString();
            Debug.Log("right answer = " + rightAnswer);

        }
        DisplayAnswers();

    }

    void shuffleAnswers()
    {
        for (int i = 0; i < answersBox.Length; i++)
        {
            int rnd = Random.Range(0, answersBox.Length);
            tempBox = answersBox[rnd];
            answersBox[rnd] = answersBox[i];
            answersBox[i] = tempBox;
        }

    }
    void DisplayAnswers()
    {
        var count = -1;
        foreach (TMP_Text text in answersBox)
        {
            ++count;
            text.text = answers[count].ToString();
            text.name = answers[count].ToString();
        }
    }
}
