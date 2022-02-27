using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviourPun
{
    [Header("Attributes")]
    public float Speed;
    public float DestroyTimer;
    public bool Direction;
    public float damage = 100;


    private void Awake()
    {
        StartCoroutine("Destroy");
    }

    private void Update()
    {
        if(!Direction)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(DestroyTimer);
        this.GetComponent<PhotonView>().RPC("DestroyObject", RpcTarget.All);
    }

    [PunRPC]

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    [PunRPC]
    public void ChangeDir_Left()
    {
        Direction = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!photonView.IsMine)
            return;

        PhotonView target = collision.gameObject.GetComponent<PhotonView>();

        if (target != null && (!target.IsMine || target.IsRoomView))
        {
            if(target.tag == "playerAB1" | target.tag == "playerAB2")
            {
                target.RPC("ReduceHealth", RpcTarget.All, damage);
            }
            this.GetComponent<PhotonView>().RPC("DestroyObject", RpcTarget.All);
        }
    }
}
