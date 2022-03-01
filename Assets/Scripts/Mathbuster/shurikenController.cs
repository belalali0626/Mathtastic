using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenController : MonoBehaviourPun
{
    [Header("Attributes")]
    public float DestroyTimer;


    private void Awake()
    {
        StartCoroutine("Destroy");
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(DestroyTimer);
        this.GetComponent<PhotonView>().RPC("DestroyObject", RpcTarget.All);
    }

    [PunRPC]public void DestroyObject()
    {
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!photonView.IsMine)
            return;

        PhotonView target = collision.gameObject.GetComponent<PhotonView>();

        if (target != null && (!target.IsMine || target.IsRoomView))
        {
            if (target.tag == "Player2" | target.tag == "Player")
            {
                target.RPC("Stun", RpcTarget.All);
            }
            this.GetComponent<PhotonView>().RPC("DestroyObject", RpcTarget.All);
        }
    }
}
