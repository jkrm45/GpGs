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
    
        Loading.value = Loading.value + Time.deltaTime * 0.1f;
        if (Loading.value <0.5)
        {
            LoadingTexture.mainTexture = LoadTexture[0];
            //LoadingPannel.SetActive(false);
        }
        if (Loading.value >= 0.5 && Loading.value < 1)
        {
            LoadingTexture.mainTexture = LoadTexture[1];
            //LoadingPannel.SetActive(false);
        }
        if (Loading.value == 1)
        {
            //LoadingTexture.mainTexture = LoadTexture[1];
            LoadingPannel.SetActive(false);
        }
        Sircletime1 = Sircletime1 - Time.deltaTime;
        Sircletime2 = Sircletime2 - Time.deltaTime;
        Sircletime3 = Sircletime3 - Time.deltaTime;
        Sircletime4 = Sircletime4 - Time.deltaTime;
        if (Sircletime1 > 0)
        {
            ReamainTimeText.text = "" + (int)Sircletime1;
        }
        else
        {
            if (Sircletime2 > 0)
            {
                ReamainTimeText.text = "" + (int)Sircletime2;

            }
            else
            {
                if (Sircletime3 > 0)
                {
                    ReamainTimeText.text = "" + (int)Sircletime3;

                }
                else
                {
                    if (Sircletime4 > 0)
                    {
                        ReamainTimeText.text = "" + (int)Sircletime4;

                    }
                }
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
}
