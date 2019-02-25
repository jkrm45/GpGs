﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomMenberCount : MonoBehaviour
{
    public int RoomMenber;
    public bool Wingame;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PhotonView>().ObservedComponents.Add(this);
    }

  
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(Wingame);
            stream.SendNext(RoomMenber);
        }
        else
        {
            Wingame = Convert.ToBoolean(stream.ReceiveNext());
            RoomMenber = Convert.ToInt32(stream.ReceiveNext());
        }
    }
    public void GG()
    {
        Knowwin();
        GetComponent<PhotonView>().RPC("Knowwin", PhotonTargets.Others);
    }
    [PunRPC]
    void Knowwin()
    {
        Wingame = true;
    }
    public void Onekill()
    {
        Diep();
        //GetComponent<PhotonView>().RPC("Diep", PhotonTargets.Others);
    }
    [PunRPC]
    void Diep()
    {
        RoomMenber--;
    }
}
