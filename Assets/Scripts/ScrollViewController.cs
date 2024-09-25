using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScrollViewController : MonoBehaviour
{
    [SerializeField] int numberofcards = 10; //�׽�Ʈ�� �����ϰ��ϱ� ���� ������ ����
    [SerializeField] GameObject cardpref; // �������� ����Ʈ�� �����ϱ� ����
    [SerializeField] Transform cardPos;// ��ũ�� UI�� �θ� �ش��ϴ� ��
    
    private void Start()
    {
        SetCards();//���۽� �� ���� �ִ� ī���� ������
        
    }

    private void SetCards()
    {

        numberofcards = MyChardsManager.Instance.mydeck.Count;
        //numberofcards = 10;
        for (int i = 0; i < numberofcards; i++)
        {
           GameObject cardsBtn = Instantiate(cardpref, cardPos) as GameObject; //�� ���� �ִ� ī��� ����
           cardsBtn.GetComponent<CharacterSelect>().cardsIndex = i;//��ȣ �ΰ�
           cardsBtn.GetComponent<CharacterSelect>().controller = this;//��ũ�� ��Ʈ�ѷ� �Ҵ�
            cardsBtn.GetComponent<Image>().sprite = MyChardsManager.Instance.mydeck[i].img;//�� ���� �ִ� ī���� �׸� �Ҵ�


        }
    }

}
