using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class questionChecker : MonoBehaviour
{
    private randomquestion randomQ;
    public GameObject GameManager;
    public string playerTag;
    public GameObject enemy;
    public int GiveDamage = 40;
    public string EnemyName;

    private void Awake()
    {
        randomQ = GameManager.GetComponent<randomquestion>();
    }

    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag(EnemyName);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == playerTag)
        {
            if(gameObject.name == randomQ.rightAnswer)
            {
                Debug.Log("RIGHT");

                enemy.GetComponent<iDamageable>()?.TakeDamage(GiveDamage);

                randomQ.Question();
                FindObjectOfType<AudioManager>().Play("score");

            }
            else
            {
                FindObjectOfType<AudioManager>().Play("wrong");
                Debug.Log("Wrong");
            }
        }
    }
}
