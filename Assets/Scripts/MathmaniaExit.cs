using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathmaniaExit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<ServerHandler>().LeaveLobby();
        }
    }
}
