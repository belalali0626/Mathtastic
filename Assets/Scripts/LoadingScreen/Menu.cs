using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName;
    public bool open;

    public void Open()
    {
        open = false;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        open = true;
        gameObject.SetActive(false);
    }
}
