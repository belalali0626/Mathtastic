using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool faceRight = true;

    [Header("Vertical Movement")]
    public float jumpSpeed;
    public float jumpDelay = 0.25f;
    private float jumpTimer;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask groundLayer;
    PhotonView view;


    [Header("Physics")]
    public float maxSpeed;
    public float linearDrag = 4f;
    public float gravity = 1f;

    [Header("Collision")]
    public bool onGround = false;
    public Vector3 colliderOffset;
    public float groundLength = 0.6f;
    public float fallMultiplier = 5f;

    [Header("UI")]
    public TMP_Text PlayerNameText;
    public SpriteRenderer SR;
    public Color enemyColour;

    [Header("Prefabs")]
    public GameObject Bullet;
    public Transform shootPos;


    void Start()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            PlayerNameText.text = PhotonNetwork.NickName;
        }

        else
        {
            PlayerNameText.text = view.Owner.NickName;
            PlayerNameText.color = Color.red;
            SR.color = enemyColour;
        }
    }

    void FixedUpdate()
    {
        characterMovement(direction.x);
        if(jumpTimer > Time.time && onGround)
        {
            Jump();
        }
        physicsHandler();
        AnimGroundCheck();
        
    }
    void Update()
    {
        if (!view.IsMine)
            return;

        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
        

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void characterMovement(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);
        anim.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Vertical", Mathf.Abs(rb.velocity.y));

        if((horizontal > 0  && !faceRight) || (horizontal < 0 && faceRight))
        {
            Flip();
        }

        //Setting Max Speed
        if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    void physicsHandler()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0;
            }
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;

            if(rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }
    void Flip()
    {
        faceRight = !faceRight;
        transform.rotation = Quaternion.Euler(0, faceRight ? 0 : 180, 0);
    }

    void AnimGroundCheck()
    {
        if(!onGround)
        {
            anim.SetBool("Jump", true);
        }
        if (onGround)
        {
            anim.SetBool("Jump", false);
        }
    }
    
    private void Shoot()
    {
        if(faceRight == true)
        {
            GameObject obj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Bullet"), new Vector2(shootPos.transform.position.x, shootPos.transform.position.y), Quaternion.identity, 0);
            anim.SetTrigger("Shoot");

        }
        if(faceRight == false)
        {
            GameObject obj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Bullet"), new Vector2(shootPos.transform.position.x, shootPos.transform.position.y), Quaternion.identity, 0);
            obj.GetComponent<PhotonView>().RPC("ChangeDir_Left", RpcTarget.All);
            anim.SetTrigger("Shoot");

        }
    }

    [PunRPC]void WinCheck(bool wim)
    {
        if(wim == true)
        {
            Debug.Log("WIN");
        }
    }

    [PunRPC]void LossCheck(bool loss)
    {
        Debug.Log("Loss");

    }
}
