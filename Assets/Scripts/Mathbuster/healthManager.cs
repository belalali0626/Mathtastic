using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public GameObject Player;
    public float PlayerHealth;
    PhotonView view;

    void Start()
    {
        Player = this.gameObject;
        view = Player.GetComponent<PhotonView>();
    }


    private void Update()
    {

        HealthCheck();

        if (PlayerHealth < 0)
        {
            if(view.IsMine)
            {
                Loss();
            }
            if (!view.IsMine)
            {
                Win();
            }
        }
    }

    void HealthCheck() 
    
    {
        PlayerControllerMB PC = Player.GetComponent<PlayerControllerMB>();
        PlayerHealth = PC.CurrentHealth;

    }


    void Loss()
    {
        GameManagerM.instance.Loser = true;

    }

    void Win()
    {
        GameManagerM.instance.Winner = true;
    }


}
