using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManagerR : MonoBehaviour
{
    [Header("Components")]
    PhotonView PhoView;
    
    [Header("Game Objects")]
    GameObject GM1;
    GameObject GM2;


    private void Awake()
    {
        PhoView = GetComponent<PhotonView>();
        GM1 = GameObject.FindGameObjectWithTag("GM1");
        GM2 = GameObject.FindGameObjectWithTag("GM2");

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

        Destroy(GM2);


    }

    void CreateController2()
    {
        Transform spawnpoint2 = SpawnManager.Instance.spawnpoint2();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerR2"), spawnpoint2.position, spawnpoint2.rotation);

        Destroy(GM1);

    }
}
