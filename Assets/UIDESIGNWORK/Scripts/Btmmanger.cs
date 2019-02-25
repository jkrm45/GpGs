using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btmmanger : MonoBehaviour
{
    public UISlider Sound;
  
    public AudioSource Music;
    public AudioSource EffectMusic;
    public AudioSource PlayerSound;
    public UILabel Scorepoint;
    public UILabel KillLabel;

    public UILabel IdCheck;


    public GameObject MenuBg;
    public GameObject Myscorebg;
    public GameObject SoundOptionbg;


   
    // Start is called before the first frame update
    void Start()
    {
        Music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        EffectMusic = GameObject.FindGameObjectWithTag("IngameSound").GetComponent<AudioSource>();


        Sound.value = PlayerPrefs.GetFloat("SaveSound");
   
    }

    // Update is called once per frame
    void Update()
    {

 
        if (Application.loadedLevelName == "Menu")
        {
            Music.volume = Sound.value;
           
            Scorepoint.text = LoginManager.Instance.UserScore.ToString();
            KillLabel.text = LoginManager.Instance.UserKillnum.ToString();
        }
        if (Application.loadedLevelName == "IngameUI")
        {
            Music.volume = 0;
            EffectMusic.volume = 0.5f;
            if (PlayerSound != null)
            {
                PlayerSound.volume = 1;
            }
          
        }
    }
    public void MyscoreOn()
    {
        Myscorebg.transform.localPosition= new Vector3(-39, 0, 0);
    }
    public void SoundOptionOn()
    {
        Sound.value = PlayerPrefs.GetFloat("SaveSound");
      
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
    
    }
    public void SoundOk()
    {
        PlayerPrefs.SetFloat("SaveSound", Sound.value);
   
    }

    public void GameQuit()
    {
        LoginManager.Instance.InfoUpdata();
       
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
        StartCoroutine(Gee());
    }

    IEnumerator Gee()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Playercnt>().isdead =true;
        LoginManager.Instance.InfoUpdata();
        yield return new WaitForSeconds(0.5f);
        PhotonNetwork.Disconnect();
        Application.LoadLevel(1);
        yield return null;

    }


}
