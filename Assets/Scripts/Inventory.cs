﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class Inventory : MonoBehaviour
{
    public string itemlist;
    public Playercnt p;
    public int helmetlv;
    public int helmethp;
    public int curslot;
    public string cursort;
    public string cureft;
    public int curdmg;
    public int curammo;
    public float usingtime;
    public GameObject itembox;
    public List<string> weaponlist;
    public List<int> weaponindex;
    public List<int> remainammoinweapon;
    public List<int> remainammoininventory;
    public List<int> cartridge;
    public List<GameObject> weaponlook;
    public List<GameObject> helmetlook;
    public UISprite Invensprite;
    public UILabel Contlabel;


    public void UnityGetInfor()
    {
        itemlist = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "itemlist"));
    }

    public void AndroidGetInfor()
    {
        itemlist = File.ReadAllText(Path.Combine(Application.persistentDataPath, "itemlist"));

    }

    void Start()
    {

#if UNITY_EDITOR
        {
            UnityGetInfor();
        }
#else


        {
            AndroidGetInfor();
        }
#endif
        Invensprite = GameObject.Find("Invensprite").GetComponent<UISprite>();
        Contlabel = GameObject.Find("ContLable").GetComponent<UILabel>();
        weaponlist.Add("dagger");
        weaponindex.Add(0);
        remainammoinweapon.Add(0);
        remainammoininventory.Add(0);
        cartridge.Add(0);
        for (int i = 0; i < 6; i++)
        {
            weaponlist.Add("");
            weaponindex.Add(0);
            remainammoinweapon.Add(0);
            remainammoininventory.Add(0);
            cartridge.Add(0);
        }
        Selectweapon(0, 0);
        p.Charidle();

    }

     void Update()

    {
        //Invensprite = GameObject.Find("Invensprite").GetComponent<UISprite>();
        //Contlabel = GameObject.Find("ContLable").GetComponent<UILabel>();
        //Contlabel.text = curammo + "/" + remainammoininventory[curslot];
        if (p.pv.isMine)
        { 
         Contlabel.text = curammo + "/" + remainammoininventory[curslot];
        if (weaponindex[curslot] == 0)
        {
            Invensprite.spriteName = "Knife";
          
        }
        if (weaponindex[curslot] == 1)
        {
            Invensprite.spriteName = "long sword";
        
        }
        if (weaponindex[curslot] == 2)
        {
            Invensprite.spriteName = "arrow";
           
        }
        if (weaponindex[curslot] == 3)
        {
            Invensprite.spriteName = "poison arrow";
         
        }
        if (weaponindex[curslot] == 4)
        {
            Invensprite.spriteName = "fire staff";
          
        }
        if (weaponindex[curslot] == 5)
        {
            Invensprite.spriteName = "ice staff";
          
        }
        if (weaponindex[curslot] == 6)
        {
            Invensprite.spriteName = "lightning staff";
          
        }
        if (weaponindex[curslot] == 10)
        {
            Invensprite.spriteName = "bandage";
          
        }
        if (weaponindex[curslot] == 11)
        {
            Invensprite.spriteName = "meat";
        
        }
        if (weaponindex[curslot] == 12)
        {
            Invensprite.spriteName = "wine";
          
        }
        if (weaponindex[curslot] == 13)
        {
            Invensprite.spriteName = "beer";
           
        }
        }

    }

    public void Frontweapon()
    {
        Beforeslot(curslot);
        Selectweapon(curslot, weaponindex[curslot]);
    }
    public void Beforeslot(int slot)
    {
        int s = slot - 1;
        if(s<0)
        {
            s = 6;
        }
        if (weaponlist[s]=="")
        {   
            Beforeslot(s);
            return;
        }
        curslot = s;
    }
    public void Backweapon()
    {
        Nextslot(curslot);
        Selectweapon(curslot, weaponindex[curslot]);
    }
    public void Nextslot(int slot)
    {
        int s = slot + 1;
        if(s>6)
        {
            s = 0;
        }
        if (weaponlist[s] == "")
        {
            Nextslot(s);
            return;
        }
        curslot = s;
    }

    public void Selectweapon(int slotnum,int itemindex)
    {
        Loaditem(slotnum, itemindex);
    }
    public void Loaditem(int slotnum, int itemindex)
    {
        var item = JSON.Parse(itemlist);
        cureft = item[itemindex]["eft"];
        cursort = item[itemindex]["sort"];
        curdmg = item[itemindex]["val"];
        curammo = remainammoinweapon[slotnum];
        usingtime = item[itemindex]["usingtime"];
    }
    
    public void Createitem(int itemindex,int itemstack)
    {
        var item = JSON.Parse(itemlist);
        string sort = item[itemindex]["sort"];
        string n = item[itemindex]["name"];
        switch (sort)
        {
            case "melee":
                Throwitem(0);
                Createweapon(0, itemindex, itemstack);
                p.Charidle();
                break;
            case "range":
                if (weaponlist[1] == "" && weaponlist[2] == "")
                {
                    Createweapon(1, itemindex, itemstack);
                    break;
                }
                else if((weaponlist[1] != "" && weaponlist[2] == ""))
                {
                    if (weaponlist[1] == n)
                    {
                        Addammo(1, itemstack);
                    }
                    else
                    {
                        Createweapon(2, itemindex, itemstack);
                    }
                    break;
                }
                else if ((weaponlist[1] != "" && weaponlist[2] != ""))
                {
                    if(n!= weaponlist[1]&&n!= weaponlist[2])
                    {
                        int i = 0;
                        int j = 0;
                        switch (curslot)
                        {   
                            case 1:
                                Throwitem(1);
                                Createweapon(1, itemindex, itemstack);
                                Selectweapon(curslot, weaponindex[curslot]);
                                i = weaponindex[curslot];
                                if (i <= 3)
                                {
                                    j = 2;
                                    StartCoroutine(PII(j));
                                }
                                else if (i <= 6)
                                {
                                    j = 3;
                                    StartCoroutine(PII(j));
                                }
                                break;
                            case 2:
                                Throwitem(2);
                                Createweapon(2, itemindex, itemstack);
                                Selectweapon(curslot, weaponindex[curslot]);
                                i = weaponindex[curslot];
                                if (i <= 3)
                                {
                                    p.Job = 2;
                                    StartCoroutine(PII(j));
                                }
                                else if (i <= 6)
                                {
                                    p.Job = 3;
                                    StartCoroutine(PII(j));
                                }
                                break;
                            default:
                                Throwitem(1);
                                Createweapon(1, itemindex, itemstack);
                                break;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < 3; i++)
                        {
                            if (weaponlist[i] == n)
                            {
                                Addammo(i, itemstack);
                                break;
                            }
                        }
                    }
                }
                break;
            case "armor":
                if(helmetlv!=0)
                {
                    GameObject i = Instantiate(itembox, transform.position, transform.rotation);
                    i.GetComponent<Itemstat>().index = helmetlv + 6;
                    i.GetComponent<Itemstat>().bullet = helmethp;
                    i.GetComponent<Itemstat>().Decidelook();
                }
                helmetlv = itemindex - 6;
                helmethp = itemstack;
                for (int i = 0; i < 3; i++)
                {
                    if (i == helmetlv - 1)
                    {
                        helmetlook[i].SetActive(true);
                    }
                    else
                    {
                        helmetlook[i].SetActive(false);
                    }
                }
                break;
            case "insheal":
                switch (itemindex)
                {
                    case 10:
                        if(weaponlist[3] == "")
                        {
                            Createweapon(3, itemindex, itemstack);
                        }
                        else
                        {
                            Addammo(3, itemstack);
                        }
                        break;
                    case 11:
                        if (weaponlist[4] == "")
                        {
                            Createweapon(4, itemindex, itemstack);
                        }
                        else
                        {
                            Addammo(4, itemstack);
                        }
                        break;
                }
                break;
            case "dotheal":
                switch (itemindex)
                {
                    case 12:
                        if (weaponlist[5] == "")
                        {
                            Createweapon(5, itemindex, itemstack);
                        }
                        else
                        {
                            Addammo(5, itemstack);
                        }
                        break;
                    case 13:
                        if (weaponlist[6] == "")
                        {
                            Createweapon(6, itemindex, itemstack);
                        }
                        else
                        {
                            Addammo(6, itemstack);
                        }
                        break;
                }
                break;
        }
    }
    public void Createweapon(int slot,int itemindex,int ammo)
    {
        var item = JSON.Parse(itemlist);
        weaponlist[slot] = item[itemindex]["name"];
        weaponindex[slot] = itemindex;
        cartridge[slot] = item[itemindex]["bullet"];
        if(ammo>= item[itemindex]["bullet"])
        {
            remainammoinweapon[slot] = item[itemindex]["bullet"];
            remainammoininventory[slot] = ammo - item[itemindex]["bullet"];
        }
        else
        {
            remainammoinweapon[slot] = ammo;
        }
    }
    public void Throwitem(int slot)
    {
        GameObject i = Instantiate(itembox,transform.position,transform.rotation);
        i.GetComponent<Itemstat>().index = weaponindex[slot];
        i.GetComponent<Itemstat>().bullet = remainammoinweapon[slot]+remainammoininventory[slot];
        i.GetComponent<Itemstat>().Decidelook();
    }
    public void Addammo(int slot,int ammo)
    {
        remainammoininventory[slot] += ammo;
    }

    IEnumerator PII(int a)
    {
        p.Job = a;
        p.ChangeOn();
        yield return new WaitForSeconds(0.2f);
        p.Charidle();
    }

}