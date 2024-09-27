using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyChardsManager : MonoBehaviour
{

    private static MyChardsManager instance;
    public static MyChardsManager Instance
    {
        get
        {if (null == instance)
            {
                return null;
            }
            return instance;
        }}//싱글톤을 위한 부분

    public GachaPool pool;//가챠 정보 가져오기
    public List<CardInfo> mydeck;//내가 가지고 있는 카드들
    private int max_count;//현재 출시된 전체 캐릭터 종류
    public BitArray mypool;
    public int cash = 0;

 

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);

        }
        else
        {

            Destroy(this.gameObject);
        }//싱글톤으로 세팅하기 위한 부분



        max_count = pool.Commmon.Length + pool.Epic.Length + pool.Unique.Length + pool.Legendary.Length;
        mypool = new BitArray(max_count);
    }

   






}
