using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerManager : MonoBehaviour
{
    PhotonView PhoView;

    //UI Elements
    public GameObject MasterClientQUI;
    GameObject OtherClientQUI;

    private void Awake()
    {
        PhoView = GetComponent<PhotonView>();

        //Finding UI Elements & Setting False
        MasterClientQUI = GameObject.FindGameObjectWithTag("playerAB1");
        OtherClientQUI = GameObject.FindGameObjectWithTag("playerAB2");

    }

    public void Start()
    {

        if (PhotonNetwork.IsMasterClient && PhoView.IsMine)
        {
            CreateController();

        }

        else if (PhoView.IsMine)
        {
            CreateController2();

        }
    }

    void CreateController()
    {
        Transform spawnpoint = SpawnManager.Instance.spawnpoint1();

        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), spawnpoint.position, spawnpoint.rotation);

        //Setting UI True for MasterClient
        OtherClientQUI.SetActive(false);

    }

    void CreateController2()
    {
        Transform spawnpoint = SpawnManager.Instance.spawnpoint2();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "second"), spawnpoint.position, spawnpoint.rotation);

        //Setting UI True for OtherClient
        MasterClientQUI.SetActive(false);

    }
}
