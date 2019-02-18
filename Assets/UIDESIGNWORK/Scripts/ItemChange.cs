using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class ItemChange : MonoBehaviour
{
    public List<string> Itemname;
    public Dictionary<int, string> havingitem;
    public int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        Itemname = new List<string>();
        havingitem = new Dictionary<int, string>();
        var N = JSON.Parse(DataInfomation.Instance.Data1.text);
        for (int i = 0; i < N.Count; i++)
        {
            Itemname.Add(N[i]["name"]);
        }
        //플레이어가 먹으면 딕셔러리값 !!
        havingitem.Add(1, "1lv helmet");
        havingitem.Add(2, "bandage");
        havingitem.Add(3, "beer");
        havingitem.Add(4, "meat");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void afterItemchange()
    {

        if (i <= havingitem.Count) //가지고있는 아이템수보다 작을떄
        {
            gameObject.GetComponent<UISprite>().spriteName = havingitem[i];
            i = i + 1;
            Debug.Log(i);
        }
        else
        {
            
            gameObject.GetComponent<UISprite>().spriteName = havingitem[i];
            i = 1;

        }
            
        
       
    }
    public void beforeItemchange()
    {
        if (i > 0 && i<=havingitem.Count) //가지고있는 아이템수보다 작을떄
        {
            gameObject.GetComponent<UISprite>().spriteName = havingitem[i];
            i = i - 1;
            Debug.Log(i);
        }
        else
        {
          
            gameObject.GetComponent<UISprite>().spriteName = havingitem[i];
            i = havingitem.Count;

        }


    }
}
