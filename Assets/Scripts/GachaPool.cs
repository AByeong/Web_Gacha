using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterPool", menuName = "CharacterPool")]
public class GachaPool : ScriptableObject
{
    public CardInfo[] Commmon; //Ŀ�� ����� ī���
    public CardInfo[] Epic; // ���� ����� ī���
    public CardInfo[] Unique; //����ũ ����� ī���
    public CardInfo[] Legendary; //������ ����� ī���


    public int[] RateTable = { 80, 95, 98, 100 };


}

    


