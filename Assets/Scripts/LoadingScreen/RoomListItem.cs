﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;
using System;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text;


    public RoomInfo info;


    public void SetUp(RoomInfo _info)
    {
        info = _info;
        text.text = info.Name;
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(info);
    }

    internal void SetUp(Player newPlayer)
    {
        throw new NotImplementedException();
    }
}
