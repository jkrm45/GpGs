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
    // Start is called before the first frame update
    void Start()
    {
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
        Cool = GameObject.Find("BlueZone").GetComponent<Circle>().sirclecooltime;
     
        if (Loading.value <0.5)
        {
            Loading.value = Loading.value + Time.deltaTime * 0.1f;
            LoadingTexture.mainTexture = LoadTexture[0];
            //LoadingPannel.SetActive(false);
        }
        if (Loading.value >= 0.5 && Loading.value < 1 && GameObject.Find("Photon").GetComponent<Gamestart>().minpnum<=PhotonNetwork.room.playerCount)
        {
            Loading.value = Loading.value + Time.deltaTime * 0.1f;
            LoadingTexture.mainTexture = LoadTexture[1];
            //LoadingPannel.SetActive(false);
        }
        if (Loading.value == 1)
        {
            Loading.value = Loading.value + Time.deltaTime * 0.1f;
            //LoadingTexture.mainTexture = LoadTexture[1];
            LoadingPannel.SetActive(false);
            GameObject.Find("BlueZone").GetComponent<Circle>().loadbafinish = true;
        }

        //if (GameObject.Find("BluZone").GetComponent<Circle>().first == true)
        //{
        //    ReamainTimeText.text = "" + (int)(Sircletime1 - Cool);
        //}
        //if (GameObject.Find("BluZone").GetComponent<Circle>().scond == true)
        //{
        //    ReamainTimeText.text = "" + (int)(Sircletime2 - Cool);
        //}
        //if (GameObject.Find("BluZone").GetComponent<Circle>().third == true)
        //{
        //    ReamainTimeText.text = "" + (int)(Sircletime3 - Cool);
        //}
        //if (GameObject.Find("BluZone").GetComponent<Circle>().fourh == true)
        //{
        //    ReamainTimeText.text = "" + (int)(Sircletime4 - Cool);
        //}




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
}
