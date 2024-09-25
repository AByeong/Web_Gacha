using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterPool", menuName = "CharacterPool")]
public class GachaPool : ScriptableObject
{
    public CardInfo[] Commmon; //커먼 등급의 카드들
    public CardInfo[] Epic; // 에픽 등급의 카드들
    public CardInfo[] Unique; //유니크 등급의 카드들
    public CardInfo[] Legendary; //레전드 등급의 카드들


    public int[] RateTable = { 80, 95, 98, 100 };


}

    


