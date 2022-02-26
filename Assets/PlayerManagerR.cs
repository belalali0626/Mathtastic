using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManagerR : MonoBehaviour
{
    PhotonView PhoView;

    public GameObject player;


    private void Awake()
    {
        PhoView = GetComponent<PhotonView>();


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

        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerR"), spawnpoint.position, spawnpoint.rotation);


    }

    void CreateController2()
    {
        Transform spawnpoint = SpawnManager.Instance.spawnpoint2();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "secondR"), spawnpoint.position, spawnpoint.rotation);


    }
}
