using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviourPun
{
    public Image fillImage;
    public int maxHealth = 100;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    [PunRPC] void ReduceHealth(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
