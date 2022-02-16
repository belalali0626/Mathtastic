using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiHandler : MonoBehaviour
{
    Animator anim;

    public GameObject gui;

    void Start()
    {
        anim = gui.GetComponent<Animator>();
        
    }

    public void p2n()
    {
        anim.SetBool("playToName", true);
    }

    public void n2g()
    {
        anim.SetBool("nameToGame", true);
        anim.SetBool("playToName", false);

    }

    public void g2l()
    {
        anim.SetBool("gameToLobby", true);
        anim.SetBool("nameToGame", false);

    }

    public void l2s()
    {
        anim.SetBool("lobbyToStart", true);
        anim.SetBool("gameToLobby", false);
        anim.SetBool("startBack", false);

    }

    public void l2g()
    {
        anim.SetBool("startBack", false);
        anim.SetBool("gameToLobby", false);
    }

    public void startBack()
    {
        anim.SetBool("lobbyToStart", false);
        anim.SetBool("startBack", true);
    }

    public void backGame()
    {
        anim.SetBool("gameToLobby", true);
        anim.SetBool("startBack", false);
    }


}
