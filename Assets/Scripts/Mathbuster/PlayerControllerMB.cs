using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class PlayerControllerMB : MonoBehaviour, iDamageable
{
    public Rigidbody2D rb;

    public Animator Anim;


    //Photon Stuff
    PhotonView view;
    PlayerControllerMB playerControl;

    // crosshair for shooting   
    public GameObject crosshair;
    public bool endOfAiming;
    public TMP_Text PlayerNameText;
    
    [Header("Player Attributes")]
    public float moveSpeed = 5f;
    public float shu_base_speed = 1.0f;
    Vector2 movement;
    const float maxHealth = 100f;
    public float CurrentHealth = maxHealth;
    public Image fillImage;
    public ProgressBarPro progress;

    [Header("Prefabs")]

    public GameObject shuriken;



    void Start()
    {
        view = GetComponent<PhotonView>();
        playerControl = this.GetComponent<PlayerControllerMB>();

        if (view.IsMine)
        {
            PlayerNameText.text = PhotonNetwork.NickName;
        }

        else
        {
            PlayerNameText.text = view.Owner.NickName;
            PlayerNameText.color = Color.red;
        }

    }
    void Update()
    {
        if (!view.IsMine)
            return;
        
        Aim();
        ProcessInput();
        Shoot();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Animator
        Anim.SetFloat("Horizontal", movement.x);
        Anim.SetFloat("Vertical", movement.y);
        Anim.SetFloat("Speed", movement.sqrMagnitude);






    }

    private void FixedUpdate() 
    {

            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        


    }

    void ProcessInput()
    {
        endOfAiming = Input.GetButtonUp("Fire1");
    }

    void Aim()
    {
        Cursor.visible = false;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.localPosition = mousePos;

     }

    void Shoot()
    {
        Vector2 ShootingDirection = crosshair.transform.localPosition;
        ShootingDirection.Normalize();


        if (endOfAiming)
        {
            Debug.Log("Hii");
            GameObject shu = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","shuriken"), transform.position, Quaternion.identity);
            shu.GetComponent<Rigidbody2D>().velocity = ShootingDirection * shu_base_speed;
            shu.transform.Rotate(0, 0, Mathf.Atan2(ShootingDirection.y, ShootingDirection.x) * Mathf.Rad2Deg);
        }

    }

    public void TakeDamage(float damage)
    {
        view.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (view.IsMine)
        {
            CurrentHealth -= damage;
            float health = CurrentHealth / maxHealth;
            progress.SetValue(health);
        }
        else if (!view.IsMine)
        {
            CurrentHealth -= damage;
            float health = CurrentHealth / maxHealth;
            progress.SetValue(health); ;
        }
    }

    [PunRPC] void Stun()
    {
        Anim.SetBool("Stun", true);
        playerControl.enabled = false;
        StartCoroutine(WaitForStunToEnd());
    }
    IEnumerator WaitForStunToEnd()
    {
        yield return null;
        yield return new WaitForSeconds(5f);
        Anim.SetBool("Stun", false);
        playerControl.enabled = true;
    }

}
