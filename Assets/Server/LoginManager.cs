using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;
using System.Text;
using SimpleJSON;
using System.IO;

public class LoginManager : MonoBehaviour
{
    private static LoginManager _instance = null;
    public static LoginManager Instance { get { return _instance; } }
    public UILabel LogText;
    public string ID;
    public int UserScore;
    public int UserKillnum;

    public string UserCheckURL;
    public string UserMakeURL;
    public string UserUpdateURL;
    public string UserInformationDelURL;
    public string downloadURL;
    private void Awake()
    {
        _instance = this;

    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();


        //StartCoroutine(LoginSytem());
        StartCoroutine(UserChecking());
    }

    void Update()
    {
      
     
    }


   


    IEnumerator LoginSytem()
    {
        yield return new WaitForSeconds(2);
        Social.localUser.Authenticate(success =>
        {
            if (true == success)
            {
                LogText.text = "Success";
                PlayerPrefs.SetString("ID", Social.localUser.userName);
                ID = PlayerPrefs.GetString("ID");


                StartCoroutine(UserChecking());
                //StartCoroutine(Next()); //에셋버들
                //서버로 아이뒤보내고 없으면 데이터 생성 있으면 정보값찾기


            }
            else
            {
                LogText.text = "Retry";
                StartCoroutine(LoginSytem());
            }

        });

    }  //로그인


    IEnumerator Next()
    {
        WWW ww = new WWW(downloadURL);
        yield return ww;
        if (ww.isDone)
        {
         
            File.WriteAllBytes(Path.Combine(Application.persistentDataPath, "itemlist"), ww.bytes);
            //string myLoadedAssetBundle2 = File.ReadAllText(Path.Combine(Application.persistentDataPath, "itemlist"));
 


        }
    } //실패시 재로그인

    IEnumerator UserChecking()  //아이뒤확인
    {
        WWWForm form = new WWWForm();
        form.AddField("USERNAME", ID);
        //form.AddField("USERNAME", PlayerPrefs.GetString("ID"));

        WWW www = new WWW(UserCheckURL, form);
        yield return www;
        if (www.isDone)
        {
            if (www.text == "")
            {
                print("아이뒤 만들기");
                StartCoroutine(MakeID());
                
                
            }
            else
            {
                var N = JSON.Parse(www.text);
                UserScore = (int)N["USERSCORE"];
                UserKillnum = (int)N["USERKILLNUM"];
                print("아이뒤있음");
                Application.LoadLevel(1);
            }
        }

    }

    IEnumerator MakeID()  //아이뒤생성
    {
        WWWForm form = new WWWForm();
        form.AddField("USERNAME", ID);
        //form.AddField("USERNAME", PlayerPrefs.GetString("ID"));

        WWW www = new WWW(UserMakeURL, form);
        yield return www;
        if (www.isDone)
        {
            print("아이디 생성완료");
            StartCoroutine(UserChecking());
         





        }

    }


    IEnumerator UpdaeInformation()  //업데이트
    {
        WWWForm form = new WWWForm();
        form.AddField("USERID", PlayerPrefs.GetString("ID"));
        form.AddField("USERSCORE", UserScore);

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
