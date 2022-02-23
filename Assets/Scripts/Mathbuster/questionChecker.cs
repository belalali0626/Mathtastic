using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class questionChecker : MonoBehaviour
{
    private randomquestion randomQ;
    public GameObject GameManager;
    public string playerTag;
    private void Awake()
    {
        randomQ = GameManager.GetComponent<randomquestion>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == playerTag)
        {
            if(gameObject.name == randomQ.rightAnswer)
            {
                Debug.Log("RIGHT");

                randomQ.Question();
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
    }
}
