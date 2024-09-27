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
        }}//�̱����� ���� �κ�

    public GachaPool pool;//��í ���� ��������
    public List<CardInfo> mydeck;//���� ������ �ִ� ī���
    private int max_count;//���� ��õ� ��ü ĳ���� ����
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
        }//�̱������� �����ϱ� ���� �κ�



        max_count = pool.Commmon.Length + pool.Epic.Length + pool.Unique.Length + pool.Legendary.Length;
        mypool = new BitArray(max_count);
    }

   






}
