using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardsClass : MonoBehaviour
{
    //�޾ƿ� ī���� ����
    public CardInfo card;


    [SerializeField] private Image img;//ī���� �̹���
    [SerializeField] private TextMeshProUGUI name;//ī���� �̸�
    [SerializeField] private TextMeshProUGUI dial;//ī���� ����
    // [SerializeField] private TextMeshProUGUI ID;//ī���� ���̵�
    // Start is called before the first frame update
    void Start()
    {
        if(card != null)
        {//ī�尡 �ִٸ� ī���� �̹����� �̸�, ���� �Ҵ�
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
