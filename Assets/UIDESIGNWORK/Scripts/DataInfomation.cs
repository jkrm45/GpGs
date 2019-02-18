using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class DataInfomation : MonoBehaviour
 { 
    private static DataInfomation _instance = null;
    public static DataInfomation Instance { get { return _instance; } }
    public TextAsset Data1;

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //var N = JSON.Parse(Data1.text);
        //for (int i = 0; i < N.Count; i++)
        //{
        //    Debug.Log(N[i]["Unit"]);
        //}


    }
    void Update()
    {

    

    }


} 

