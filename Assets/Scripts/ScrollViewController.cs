using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScrollViewController : MonoBehaviour
{
    [SerializeField] int numberofcards = 10; //테스트를 용이하게하기 위해 지정한 변수
    [SerializeField] GameObject cardpref; // 동적으로 리스트를 관리하기 위함
    [SerializeField] Transform cardPos;// 스크롤 UI의 부모에 해당하는 것
    
    private void Start()
    {
        SetCards();//시작시 내 덱에 있는 카드들로 세팅함
        
    }

    private void SetCards()
    {

        numberofcards = MyChardsManager.Instance.mydeck.Count;
        //numberofcards = 10;
        for (int i = 0; i < numberofcards; i++)
        {
           GameObject cardsBtn = Instantiate(cardpref, cardPos) as GameObject; //내 덱에 있는 카드로 생성
           cardsBtn.GetComponent<CharacterSelect>().cardsIndex = i;//번호 부과
           cardsBtn.GetComponent<CharacterSelect>().controller = this;//스크롤 컨트롤러 할당
            cardsBtn.GetComponent<Image>().sprite = MyChardsManager.Instance.mydeck[i].img;//내 덱에 있는 카드의 그림 할당


        }
    }

}
