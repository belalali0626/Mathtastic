using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class randomquestion : MonoBehaviour
{
    //first value
    private int lowFirstValue = 1;
    private int highFirstValue = 10;
    public int firstValue;
    //second value
    private int lowSecondValue = 1;
    private int highSecondValue = 10;
    public int SecondValue;
    public Text gameTxt;
    public int finalValue1;
    public int finalValue2;
    public int finalValue3;
    public int finalValue4;
    

    //private bool isAdd = false;
   // private bool isSub = false;
   // private bool isMulti = false;
   // private bool isDiv = false;

    float[] answers = new float[4];
    string[] questions = new string[4];
    GameObject[] answersBox;
    

    // Start is called before the first frame update
    void Start()
    {
        Question();

    }

    void Update()
    {



    }
    void Question()
    {
        firstValue = Random.Range(lowFirstValue, highFirstValue);
        SecondValue = Random.Range(lowSecondValue, highSecondValue);
        Debug.Log("first value = " + firstValue);
        Debug.Log("second value = " + SecondValue);


        for (int e = 1; e < 5; e++)
        {

            if (e == 1)
            {
                finalValue1 = firstValue + SecondValue;
                //Debug.Log("Adding");
                //isAdd = true;
                answers[0] = finalValue1;
                questions[0] = (firstValue + " + " + SecondValue);
                Debug.Log("Value = add" + answers[0]);


            }
            if (e == 2)
            {
                finalValue2 = firstValue - SecondValue;
                // Debug.Log("Subtracting");
                // isSub = true;
                answers[1] = finalValue2;
                questions[1] = (firstValue + " - " + SecondValue);
                Debug.Log("Value = sub " + answers[1]);


            }
            if (e == 3)
            {
                finalValue3 = firstValue * SecondValue;
                //Debug.Log("Mutlipling");
                //isMulti = true;            
                answers[2] = finalValue3;
                questions[2] = (firstValue + " x " + SecondValue);
                Debug.Log("Value = multi" + answers[2]);



            }
            if (e == 4)
            {
                finalValue4 = firstValue / SecondValue;
                //Debug.Log("Dividing");
                //isDiv = true
                answers[3] = finalValue4;
                questions[3] = (firstValue + " / " + SecondValue);
                Debug.Log("Value = div" + answers[3]);


            }

        }
        EndAnswer();

    }

    void EndAnswer()
    {
        float aQnswer = answers[Random .Range(0, answers.Length)];
        Debug.Log("the array is " + aQnswer);
        
        if (aQnswer == answers[0])
        {
            gameTxt.text = questions[0];
        }       
        if (aQnswer == answers[1])
        {
            gameTxt.text = questions[1];
        }
        if (aQnswer == answers[2])
        {
            gameTxt.text = questions[2];
        }
        if (aQnswer == answers[3])
        {
            gameTxt.text = questions[3];
        }

    }

    void DisplayAnswers()
    {

    }
}
