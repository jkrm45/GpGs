using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autofllow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
     
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 75, player.transform.position.z);
        }
        if (GameObject.Find("UiManeger").GetComponent<RoadingScript>().Bulezone != null)
        {
            gameObject.SetActive(true);
        }
      
    }
}
