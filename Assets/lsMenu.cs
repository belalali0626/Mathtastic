using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lsMenu : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().StopPlaying("mathmania");
        FindObjectOfType<AudioManager>().StopPlaying("rambotown");

    }
}
