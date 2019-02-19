using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstat : MonoBehaviour 
{
    public float hp=100;
    public float dothp;
    public float dothealtime;
    public float dothealcool = 5;
    public bool poison;
    public int poisonstack;
    public bool fire;
    public int firestack;
    public bool ice;
    public int icestack;
    public UIProgressBar Hpba;
    public UIProgressBar boast;
    //public GameObject Fire;
    //public GameObject Posion;
    //public GameObject slow;
    public GameObject Fireicon;
    public GameObject PosionIcon;
    public GameObject Slowicon;
   
        


    private void Start()
    {
        Hpba = GameObject.Find("HpbaBg").GetComponent<UIProgressBar>();
        boast=GameObject.Find("BoastingBg").GetComponent<UIProgressBar>();
        Fireicon = GameObject.Find("Fireicon");
        PosionIcon = GameObject.Find("Posionicon");
        Slowicon = GameObject.Find("Slowicon");

    }
    private void Update()
    {
        Hpba.value = hp / 100;
        boast.value = dothp / 100;
        if (poison)
        {
            //Posion.SetActive(true);
            PosionIcon.SetActive(true);
        }
        else
        {
            //Posion.SetActive(false);
            PosionIcon.SetActive(false);
        }
        if (fire)
        {
            //Fire.SetActive(true);
            Fireicon.SetActive(true);
        }
        else
        {
            //Fire.SetActive(false);
            Fireicon.SetActive(false);
        }
        if (ice)
        {
            //slow.SetActive(true);
            Slowicon.SetActive(true);
        }
        else
        {
            //slow.SetActive(false);
            Slowicon.SetActive(false);
        }
    }
}
