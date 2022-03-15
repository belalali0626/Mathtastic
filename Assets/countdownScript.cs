using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownScript : MonoBehaviour
{
    [Header("Variables")]
    bool startTimer = false;
    double remainingTime;
    double timerInc;
    double startTime;
    [SerializeField] double timer = 20;

    [Header("Objects")]
    public GameObject countdown;
    public Text countdownText;

    [Header("Hashmap")]
    ExitGames.Client.Photon.Hashtable Sync;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Time.timeScale = 0;

            Sync = new ExitGames.Client.Photon.Hashtable();
            startTime = PhotonNetwork.Time;
            startTimer = true;
            Sync.Add("StartTime", startTime);
            PhotonNetwork.CurrentRoom.SetCustomProperties(Sync);
        }
        else
        {
            startTime = double.Parse(PhotonNetwork.LocalPlayer.CustomProperties["StartTime"].ToString());
            startTimer = true;
        }
    }

    void Update()
    {

        if (!startTimer) return;

        timeCalculations();

        if (timerInc >= timer)
        {
            startGame();
        }
    }

    void timeCalculations()
    {
        timerInc = PhotonNetwork.Time - startTime;

        remainingTime = Mathf.Round((float)(timer - timerInc));

        countdownText.text = remainingTime.ToString();
    }

    void startGame()
    {
        Time.timeScale = 1;
        countdown.SetActive(false);
    }

}

