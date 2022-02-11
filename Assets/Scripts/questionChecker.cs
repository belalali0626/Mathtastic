using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class questionChecker : MonoBehaviour
{
    private randomquestion randomQ;
    public GameObject player;
    private void Awake()
    {
        randomQ = player.GetComponent<randomquestion>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.name == randomQ.rightAnswer)
            {
                Debug.Log("RIGHT");
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
    }
}
