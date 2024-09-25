using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardsClass : MonoBehaviour
{
    //받아올 카드의 정보
    public CardInfo card;


    [SerializeField] private Image img;//카드의 이미지
    [SerializeField] private TextMeshProUGUI name;//카드의 이름
    [SerializeField] private TextMeshProUGUI dial;//카드의 설명
    // [SerializeField] private TextMeshProUGUI ID;//카드의 아이디
    // Start is called before the first frame update
    void Start()
    {
        if(card != null)
        {//카드가 있다면 카드의 이미지와 이름, 설명 할당
            img.sprite = card.img;
            name.text = card.name;
            dial.text = card.dial;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Start();
    }
}
