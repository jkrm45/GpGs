using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class SendDataImfo : MonoBehaviour
{
    public string UserCheckURL;
    public string UserMakeURL;
    public string UserUpdateURL;
    public string UserInformationDelURL;
    public int Scroe;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator UserChecking()  //아이뒤확인
    {
        WWWForm form = new WWWForm();
        form.AddField("USERNAME", PlayerPrefs.GetString("ID"));
      
        WWW www = new WWW(UserCheckURL, form);
        yield return www;
        if (www.isDone)
        {
            if (www.text == "")
            {
                StartCoroutine(MakeID());
            }
            else
            {
                
            }
        }

    }

    IEnumerator MakeID()  //아이뒤생성
    {
        WWWForm form = new WWWForm();
        form.AddField("USERNAME", PlayerPrefs.GetString("ID"));

        WWW www = new WWW(UserMakeURL, form);
        yield return www;
        if (www.isDone)
        {
            var N = JSON.Parse(www.text);
            Scroe = (int)N["USERSCORE"];


        }

    }

    IEnumerator UpdaeInformation()  //업데이트
    {
        WWWForm form = new WWWForm();
        form.AddField("USERSCORE", Scroe);

        WWW www = new WWW(UserUpdateURL, form);
        yield return www;
        if (www.isDone)
        {

        }

    }
    IEnumerator DelInformation()  //업데이트
    {
        WWWForm form = new WWWForm();
        form.AddField("USERNAME", PlayerPrefs.GetString("ID"));

        WWW www = new WWW(UserInformationDelURL, form);
        yield return www;
        if (www.isDone)
        {

        }

    }

}
