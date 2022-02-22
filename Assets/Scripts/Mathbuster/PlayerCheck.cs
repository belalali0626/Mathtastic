using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{

    bool Player1;

    bool Player2;

    void Update()
    {
        if(GameObject.Find("Player(Clone)"))
        {
            Player1 = true;
            Debug.Log("Player 1 found");
        }
        else if (GameObject.Find("Second"))
        {
            Player2 = true;
            Debug.Log("Player 2 found");
        }

        
    }
}
