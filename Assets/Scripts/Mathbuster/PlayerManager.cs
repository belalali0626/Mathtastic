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
    void Start()
    {
        if(PhoView.IsMine)
        {
            CreateController();
        }
        
    }

    void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), Vector3.zero, Quaternion.identity);

    }
}
