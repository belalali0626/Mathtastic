using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerM : MonoBehaviour
{
    private static GameManagerM _instance;

    public static GameManagerM instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManagerM");
                go.AddComponent<GameManagerM>();
            }
            return _instance;
        }
    }
    PhotonView view;

    [Header("UI Elements")]
    public GameObject GameStateCanvas;
    public TMP_Text GameState;

    [Header("Bool")]
    public bool Winner;
    public bool Loser;

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (Winner == true)
        {
            Win();
        }

        if (Loser == true)
        {
            Lose();
        }
    }

    void Win()
    {
        PhotonView view = PhotonView.Get(this);
        view.RPC("Timescale", RpcTarget.All);
        GameStateCanvas.SetActive(true);
        GameState.text = "You Won!";
        GameState.color = Color.green;
    }

    void Lose()
    {
        PhotonView view = PhotonView.Get(this);
        view.RPC("Timescale", RpcTarget.All);
        GameStateCanvas.SetActive(true);
        GameState.text = "You Lost!";
        GameState.color = Color.red;

    }

    [PunRPC]void Timescale()
    {
        Time.timeScale = 0;
    }
}
