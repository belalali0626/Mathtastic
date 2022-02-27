using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviourPun
{
    public Image fillImage;
    public float maxHealth = 100;
    public float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }


    [PunRPC] void ReduceHealth(float damage)
    {
        currentHealth -= damage;
        Healthbar();
        if(currentHealth <= 0)
        {
            Debug.Log("die");
        }
    }

    private void Healthbar()
    {
        if(photonView.IsMine)
        {
            fillImage.fillAmount = currentHealth / maxHealth;
        }
        else
        {
            fillImage.fillAmount = currentHealth / maxHealth;
        }
    }


}
