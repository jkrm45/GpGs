using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManmeger : MonoBehaviour
{

    private static BgmManmeger _instance = null;

    public static BgmManmeger Instance { get { return _instance; } }
    public AudioSource MusicController; // 음악
    public AudioSource InGameSoundController; // 게임 내부 바람소리 컨트롤 
    public AudioSource ActionController; // 행동소리 컨트롤러
    public AudioClip Walk;
    public AudioClip SwardAttack;
    public AudioClip ArcherAttack;
    public AudioClip MagicAttack1;
    public AudioClip MagicAttack2;
    public AudioClip MagicAttack3;
    public AudioClip Dead;
    public AudioClip hitted;

    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //ActionController = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();  //방에 접속하면 하이어라키에 플레이어 찾아게 수정!! 
        //->>>>  BgmManmeger.Instance.ActionController = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();

    }

    public void WalkSound()//이동시 발걸음  ---->   BgmManmeger.Instance.WalkSound();
    {
        ActionController.maxDistance = 10;
        ActionController.clip = Walk;
        ActionController.PlayOneShot(Walk);
    }

    public void SwardAttackSound() //기본칼 , 칼 공격사운드  ---->   BgmManmeger.Instance.SwardAttackSound();
    {
        ActionController.maxDistance = 5;
        ActionController.clip = SwardAttack;
        ActionController.PlayOneShot(SwardAttack);
    }

    public void ArcherAttackSound()//홣 공격사운드  ---->   BgmManmeger.Instance.ArcherAttackSound();
    {
        ActionController.maxDistance = 5;
        ActionController.clip = ArcherAttack;
        ActionController.PlayOneShot(ArcherAttack);
    }

    public void IceMagicAttackSound() //얼음마법사운드  ---->   BgmManmeger.Instance.IceMagicAttackSound();
    {
        ActionController.maxDistance = 20;
        ActionController.clip = MagicAttack2;
        ActionController.PlayOneShot(MagicAttack2);
    }

    public void LightingMagicAttackSound() // 나이트링마법 사운드  ---->   BgmManmeger.Instance.LightingMagicAttackSound() ;
    {
        ActionController.maxDistance = 20;
        ActionController.clip = MagicAttack3;
        ActionController.PlayOneShot(MagicAttack3);
    }

    public void FireMagicAttackSound() // 불마법사운드  ---->   BgmManmeger.Instance.FireMagicAttackSound();
    {
        ActionController.maxDistance = 20;
        ActionController.clip = MagicAttack1;
        ActionController.PlayOneShot(MagicAttack1);
    }

    public void DeadSound() // 사망사운드  ---->   BgmManmeger.Instance.DeadSound();
    {
        ActionController.maxDistance = 0.01f;
        ActionController.clip = Dead;
        ActionController.PlayOneShot(Dead);
    }

    public void HittedSound() //피격사운드  ---->   BgmManmeger.Instance.hittedSound();
    {
        ActionController.maxDistance = 0.01f;
        ActionController.clip = hitted;
        ActionController.PlayOneShot(hitted);
    }
}
