using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    [Header("Scripts")]
    private questionLogic qLogic;
    
    [Header("Objects")]
    public GameObject GameManager;

    [Header("Variables")]
    public int score = 1;

    [Header("Strings")]
    public string playerTag;

    [Header("Components")]
    PhotonView view;





    private void Awake()
    {
        view = GetComponent<PhotonView>();
        qLogic = GameManager.GetComponent<questionLogic>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PhotonView target = collision.gameObject.GetComponent<PhotonView>();

        if (collision.gameObject.tag == playerTag)
        {
            if (gameObject.name == qLogic.rightAnswer)
            {
                qLogic.Question();


                target.RPC("giveScore", RpcTarget.All, score);

                Debug.Log("Right");

            }
            else
            {
                Debug.Log("Wrong");
            }
        }
    }
}
