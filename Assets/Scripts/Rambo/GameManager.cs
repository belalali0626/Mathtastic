using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
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
        FindObjectOfType<AudioManager>().StopPlaying("MainSong");
        FindObjectOfType<AudioManager>().Play("rambotown");


    }

    void Update()
    {
        if(Winner == true)
        {
            Win();  
        }

        if(Loser == true)
        {
            Lose();
        }
    }

    void Win()
    {
        PhotonView view = PhotonView.Get(this);
        GameStateCanvas.SetActive(true);
        GameState.text = "You Won!";
        GameState.color = Color.green;
    }

    void Lose()
    {
        PhotonView view = PhotonView.Get(this);
        GameStateCanvas.SetActive(true);
        GameState.text = "You Lost!";
        GameState.color = Color.red;

    }

    [PunRPC] void Timescale ()
    {
        Time.timeScale = 0;
    }
}
