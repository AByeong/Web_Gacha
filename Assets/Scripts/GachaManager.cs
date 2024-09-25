using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class GachaManager : MonoBehaviour
{
    public GachaPool gachainfo;//가챠 정보 가져오기
    [SerializeField]private int gacharesult; //가챠 결과

    public CardInfo[] gacharesulcards = new CardInfo[10];
    public GameObject[] showcards = new GameObject[10];
    
    private string tmp; //가챠 진행하기 이전의 상태를 저장할 비트


    //public TextMeshProUGUI MYBit;
    public TextMeshProUGUI Cash;

    private void Update()
    {if(tmp == null)
        {
            tmp = "";
        }

        // 비트 배열을 문자열로 변환      
        //MYBit.text =$"MY Bit : {BitArrayToString( MyChardsManager.Instance.mypool)}, Bit tmp : {tmp}";
        Cash.text = $"MY Cash : {MyChardsManager.Instance.cash}";
    }
    public void GachaingCard(int num)
    {
        for(int i=0; i < num; i++)
        {
            tmp = BitArrayToString(MyChardsManager.Instance.mypool); // 뽑기 이전의 카드 풀 저장
            gacharesulcards[i] = Gatcha(); //뽑기로 나온 카드를 할당
            MyChardsManager.Instance.mypool.Set(gacharesulcards[i].ID ,true);//나온 카드의 아이디 할당
                       
            if (tmp == BitArrayToString(MyChardsManager.Instance.mypool))//만약 중복된 카드가 나왔다면
            {
                MyChardsManager.Instance.cash += 10;//10만큼의 cash를 더함

            }
            else
            {

                MyChardsManager.Instance.mydeck.Add(gacharesulcards[i]);
            }

            showcards[i].GetComponent<CardsClass>().card = gacharesulcards[i];//화면에 나온 카드 표시
        }

    }

   private CardInfo Gatcha()
    {//가챠를 행하는 함수
        gacharesult = Random.Range(1,100);
        
    if(gacharesult <= gachainfo.RateTable[0]) 
        { 
        }else if(gachainfo.RateTable[0]< gacharesult && gacharesult <= gachainfo.RateTable[1])
        {
            return gachainfo.Commmon[Random.Range(0,gachainfo.Commmon.Length)];//커먼 등급 카드

        }
        else if (gachainfo.RateTable[1] < gacharesult && gacharesult <= gachainfo.RateTable[2])
        {
            return gachainfo.Epic[Random.Range(0, gachainfo.Epic.Length)];//에픽 등급 카드

        }
        else if (gachainfo.RateTable[2] < gacharesult && gacharesult <= gachainfo.RateTable[3])
        {
            return gachainfo.Unique[Random.Range(0, gachainfo.Unique.Length)];//유니크 등급 카드

        }
        else
        {
            return gachainfo.Legendary[Random.Range(0, gachainfo.Legendary.Length)];//레전드 등급 카드
        }

        return gachainfo.Commmon[Random.Range(0, gachainfo.Commmon.Length)];
    }


    string BitArrayToString(BitArray bitArray)//비트어레이를 텍스트로 표기할 수 있도록해주는 함수
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < bitArray.Count; i++)
        {
            // 각 비트 값을 1 또는 0으로 변환하여 문자열에 추가
            sb.Append(bitArray[i] ? "1" : "0");
        }

        return sb.ToString();
    }

    

   


}
