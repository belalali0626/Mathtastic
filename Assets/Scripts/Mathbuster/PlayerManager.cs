using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerManager : MonoBehaviour
{
    PhotonView PhoView;


    private void Awake()
    {
        PhoView = GetComponent<PhotonView>();
    }

    public void Start()
    {
        if (PhotonNetwork.IsMasterClient && PhoView.IsMine)
        {
            CreateController();

            Debug.Log("test1");
        }

        else if (PhoView.IsMine)
        {
            CreateController2();

            Debug.Log("test2");
        }
    }

    void CreateController()
    {
        Transform spawnpoint = SpawnManager.Instance.spawnpoint1();

        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), spawnpoint.position, spawnpoint.rotation);

    }

    void CreateController2()
    {
        Transform spawnpoint = SpawnManager.Instance.spawnpoint2();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "second"), spawnpoint.position, spawnpoint.rotation);

    }
}
