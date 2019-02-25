using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadingScript : MonoBehaviour
{
    public UIProgressBar Loading;
    public UITexture LoadingTexture;
    public UILabel LoadingText;
    public GameObject LoadingPannel;
    public List<Texture> LoadTexture;
    public UILabel ReamainTimeText;
    public float Sircletime1;
    public float Sircletime2;
    public float Sircletime3;
    public float Sircletime4;
    public float Cool;
    public GameObject Mapcameracavas;
    public GameObject player;
    public GameObject Mapcamera;
    public GameObject Bulezone;
    public float t;
    public float tcool;
    public bool z;

    public GameObject[] readytostart;
    // Start is called before the first frame update
    void Start()
    {
        readytostart = new GameObject[20];
        StartCoroutine(ChangeText());
        //if (RandomTexture() == 0)
        //{
        //    LoadingTexture.mainTexture = LoadTexture[0];
        //}
        //if (RandomTexture() == 1)
        //{
        //    LoadingTexture.mainTexture = LoadTexture[1];
        //}
    }

    // Update is called once per frame
    void Update()
    {
  
     
        if (Loading.value <0.5)
        {
            Loading.value = Loading.value + Time.deltaTime * 0.1f;
            LoadingTexture.mainTexture = LoadTexture[0];
            //LoadingPannel.SetActive(false);
        }
        if (Loading.value >= 0.5 && Loading.value <=0.95f&& GameObject.Find("Photon").GetComponent<Gamestart>().minpnum<=PhotonNetwork.room.playerCount)
        {
            Loading.value = Loading.value + Time.deltaTime * 0.1f;
            LoadingTexture.mainTexture = LoadTexture[1];
            //LoadingPannel.SetActive(false);
        }
        if (Loading.value >= 0.95 && Loading.value < 0.97)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Playercnt>().dddd();
            t += Time.deltaTime;
            if (t >= 1 && z==true)
            {
                Stillwating();
                t = 0;
            }



        }
        if (Loading.value >= 0.98 && Loading.value<=1)
        {
            Loading.value = Loading.value + Time.deltaTime * 0.1f;
            //LoadingTexture.mainTexture = LoadTexture[1];
            LoadingPannel.SetActive(false);
            Mapcameracavas.SetActive(true);

            player = GameObject.FindGameObjectWithTag("Player");


            Bulezone = GameObject.Find("BlueZone");
            Bulezone.GetComponent<Circle>().loadbafinish = true;
        }
        if (player!=null)
        {
            Mapcamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y +80, player.transform.position.z);
        }

        if (Bulezone != null)
        {
            Cool = Bulezone.GetComponent<Circle>().sirclecooltime;
            if (Bulezone.GetComponent<Circle>().first == true)
            {
                ReamainTimeText.text = "" + (int)(Sircletime1 - Cool);
            }
            if (Bulezone.GetComponent<Circle>().scond == true)
            {
                ReamainTimeText.text = "" + (int)(Sircletime2 - Cool);
            }
            if ( Bulezone.GetComponent<Circle>().third == true)
            {
                ReamainTimeText.text = "" + (int)(Sircletime3 - Cool);
            }
            if (Bulezone.GetComponent<Circle>().fourh == true)
            {
                ReamainTimeText.text = "" + (int)(Sircletime4 - Cool);
            }
        }
   




    }

    IEnumerator ChangeText()
    {
        LoadingText.text = "Now Loading.";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading..";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading...";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading.";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading..";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading...";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading.";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading..";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading...";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading";
        yield return new WaitForSeconds(1);
        LoadingText.text = "Now Loading.";
        yield return new WaitForSeconds(1);
    }

    int RandomTexture()
    {
        int v;
        v = Random.Range(0, 2);
        return v;
    }

    void Stillwating()
    {

        
        for (int i = 0; i < readytostart.Length; i++)
        {
            if (!readytostart[i].GetComponent<Playercnt>().ready)
            {
                continue;
            }
            else
            {
                Loading.value = 1;
            }
        }
    }

    public void ddxxx()
    {
        readytostart = (GameObject[])GameObject.FindGameObjectsWithTag("Enemy").Clone();
        z = true;
    }
}
