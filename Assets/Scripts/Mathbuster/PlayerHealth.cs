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
    public Animator anim;
    public playerController playerControl;

    void Start()
    {
        currentHealth = maxHealth;
        anim = gameObject.GetComponent<Animator>();
        playerControl = gameObject.GetComponent<playerController>();

    }


    [PunRPC] void ReduceHealth(float damage)
    {
        currentHealth -= damage;
        Healthbar();
        if(currentHealth <= 0)
        {
                anim.SetBool("Stun", true);
                playerControl.enabled = false;
                StartCoroutine(WaitForStunToEnd());
            
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

    IEnumerator WaitForStunToEnd()
    {
        yield return null;
        yield return new WaitForSeconds(5f);
        anim.SetBool("Stun", false);
        playerControl.enabled = true;
        currentHealth = 100;
        Healthbar();
    }


}
