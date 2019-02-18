﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btmmanger : MonoBehaviour
{
    public UISlider Sound;
    public UISlider EffectSound;
    public AudioSource Music;
    public AudioSource EffectMusic;
    public AudioSource PlayerSound;
    public UILabel Scorepoint;
    public UILabel KillLabel;


    public GameObject MenuBg;
    public GameObject Myscorebg;
    public GameObject SoundOptionbg;
    // Start is called before the first frame update
    void Start()
    {
        Music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        EffectMusic = GameObject.FindGameObjectWithTag("IngameSound").GetComponent<AudioSource>();
        PlayerSound = GameObject.Find("Player").GetComponent<AudioSource>();

        Sound.value = PlayerPrefs.GetFloat("SaveSound");
        EffectSound.value = PlayerPrefs.GetFloat("SaveEffectSound");
    }

    // Update is called once per frame
    void Update()
    {
        Scorepoint.text = LoginManager.Instance.UserScore.ToString();
        KillLabel.text = LoginManager.Instance.UserKillnum.ToString();
        if (Application.loadedLevelName == "Menu")
        {
            Music.volume = Sound.value;
        }
        if (Application.loadedLevelName == "IngameUI")
        {
            Music.volume = Sound.value;
            EffectMusic.volume = EffectSound.value;
            PlayerSound.volume = EffectSound.value;
        }
    }
    public void MyscoreOn()
    {
        Myscorebg.transform.localPosition= new Vector3(-39, 0, 0);
    }
    public void SoundOptionOn()
    {
        Sound.value = PlayerPrefs.GetFloat("SaveSound");
        EffectSound.value = PlayerPrefs.GetFloat("SaveEffectSound");
        SoundOptionbg.transform.localPosition = new Vector3(-39, 2, 0);
    }
    public void Myscoreoff()
    {
        Myscorebg.transform.localPosition = new Vector3(1400, 0, 0);
    }
    public void SoundOptionoff()
    {
        SoundOptionbg.transform.localPosition = new Vector3(1400, 700, 0);
    }
    public void Playstart()
    {
        Application.LoadLevel(2);
    }
    public void SoundCancle()
    {
        Sound.value = PlayerPrefs.GetFloat("SaveSound");
        EffectSound.value = PlayerPrefs.GetFloat("SaveEffectSound");
    }
    public void SoundOk()
    {
        PlayerPrefs.SetFloat("SaveSound", Sound.value);
        PlayerPrefs.SetFloat("SaveEffectSound", EffectSound.value);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void MenuOn()
    {
        MenuBg.transform.localPosition = new Vector3(0, -2, 0);
    }
    public void MenuOff()
    {
        MenuBg.transform.localPosition = new Vector3(0, -900, 0);
    }

    public void GoMenu()
    {
        Application.LoadLevel(1);

    }


}