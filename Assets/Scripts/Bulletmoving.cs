using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmoving : MonoBehaviour
{
    public float spd;
    public float destime = 3;
    public int dmg;
    public GameObject master;
    public string eft;
    public List<GameObject> eftlist;

    void Start()
    {
        Destroy(gameObject, destime);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * spd * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            int dmgtop = 0;
            int dmgtoh = 0;
            switch (other.GetComponentInChildren<Inventory>().helmetlv)
            {
                case 0:
                    dmgtop = dmg;
                    break;
                case 1:
                    dmgtop = (int)(dmg * .8f);
                    dmgtoh = (int)(dmg * .2f);
                    break;
                case 2:
                    dmgtop = (int)(dmg * .7f);
                    dmgtoh = (int)(dmg * .3f);
                    break;
                case 3:
                    dmgtop = (int)(dmg * .6f);
                    dmgtoh = (int)(dmg * .4f);
                    break;
            }
            other.GetComponent<Playercnt>().HitRPC(dmgtop, dmgtoh, master.name);
            Destroy(gameObject);
        }
    }
    public void Decideeft(int index)
    {
        eftlist[index - 2].SetActive(true);
    }
}