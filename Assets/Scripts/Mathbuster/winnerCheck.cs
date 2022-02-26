using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winnerCheck : MonoBehaviour
{
    public string enemyTag;
    public string playerTag;
    public float PlayerHealth;
    public float EnemyHealth;

    

    private void Update()
    {

        WinCheck();

        if (PlayerHealth > 0 && EnemyHealth < 0)
        {
            Loss();
        }

        if (PlayerHealth < 0 && EnemyHealth > 0)
        {
            Win();
        }

        else if(PlayerHealth == 0 && EnemyHealth == 0)
        {
            Draw();
        }
    }

    void WinCheck() 
    
    {
        GameObject Player = GameObject.FindGameObjectWithTag(playerTag);
        PlayerControllerMB PC = Player.GetComponent<PlayerControllerMB>();

         PlayerHealth = PC.CurrentHealth;


        GameObject EnemyPlayer = GameObject.FindGameObjectWithTag(enemyTag);
        PlayerControllerMB PCE = EnemyPlayer.GetComponent<PlayerControllerMB>();

        EnemyHealth = PCE.CurrentHealth;


    }

    void Win()
    {
        Debug.Log("Win");
    }
    

    void Loss()
    {
        Debug.Log("Loss");

    }

    void Draw()
    {
        Debug.Log("Draw");

    }



}
