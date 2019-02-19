using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photoninit : MonoBehaviour
{
    public bool ready = false;
    private void Awake()
    {
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings("woophotonex");
    }
    public virtual void OnConnectedToMaster()
    {
        Debug.Log("connect master");
        PhotonNetwork.JoinRandomRoom();
    }
    public virtual void OnPhotonRandomJoinFailed()
    {
        Debug.Log("no room");
        PhotonNetwork.CreateRoom("room");
    }
    public virtual void OnCreatedRoom()
    {
        Debug.Log("create");
    }
    public virtual void OnJoinedRoom()
    {
        Debug.Log("join room");
        StartCoroutine(Createplayer());
    }

    IEnumerator Createplayer()
    {
        GameObject p = PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(-50, 51), 20, Random.Range(-75, 76)), Quaternion.identity, 0);
#if UNITY_EDITOR
        {
            p.name = "sdsdsd";
        }
#endif

#if UNITY_ANDROID
        {
            p.name = Social.localUser.userName;
        }
#endif
        ready = true;
        yield return null;
    }
}