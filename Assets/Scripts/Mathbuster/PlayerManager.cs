using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerManager : MonoBehaviour
{
    PhotonView PhoView;

    //UI Elements
    GameObject MasterClientQUI;
    GameObject OtherClientQUI;
    GameObject GM1;
    GameObject GM2;

    private void Awake()
    {
        PhoView = GetComponent<PhotonView>();

        //Finding UI Elements & Setting False
        MasterClientQUI = GameObject.FindGameObjectWithTag("playerAB1");
        OtherClientQUI = GameObject.FindGameObjectWithTag("playerAB2");
        GM1 = GameObject.FindGameObjectWithTag("GM1");
        GM2 = GameObject.FindGameObjectWithTag("GM1");

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
        GM2.SetActive(false);

    }

    void CreateController2()
    {
        Transform spawnpoint = SpawnManager.Instance.spawnpoint2();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "second"), spawnpoint.position, spawnpoint.rotation);

        //Setting UI True for OtherClient
        MasterClientQUI.SetActive(false);
        GM1.SetActive(false);


    }

}
