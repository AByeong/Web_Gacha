using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class GachaManager : MonoBehaviour
{
    public GachaPool gachainfo;//��í ���� ��������
    [SerializeField]private int gacharesult; //��í ���

    public CardInfo[] gacharesulcards = new CardInfo[10];
    public GameObject[] showcards = new GameObject[10];
    
    private string tmp; //��í �����ϱ� ������ ���¸� ������ ��Ʈ


    //public TextMeshProUGUI MYBit;
    public TextMeshProUGUI Cash;

    private void Update()
    {if(tmp == null)
        {
            tmp = "";
        }

        // ��Ʈ �迭�� ���ڿ��� ��ȯ      
        //MYBit.text =$"MY Bit : {BitArrayToString( MyChardsManager.Instance.mypool)}, Bit tmp : {tmp}";
        Cash.text = $"MY Cash : {MyChardsManager.Instance.cash}";
    }
    public void GachaingCard(int num)
    {
        for(int i=0; i < num; i++)
        {
            tmp = BitArrayToString(MyChardsManager.Instance.mypool); // �̱� ������ ī�� Ǯ ����
            gacharesulcards[i] = Gatcha(); //�̱�� ���� ī�带 �Ҵ�
            MyChardsManager.Instance.mypool.Set(gacharesulcards[i].ID ,true);//���� ī���� ���̵� �Ҵ�
                       
            if (tmp == BitArrayToString(MyChardsManager.Instance.mypool))//���� �ߺ��� ī�尡 ���Դٸ�
            {
                MyChardsManager.Instance.cash += 10;//10��ŭ�� cash�� ����

            }
            else
            {

                MyChardsManager.Instance.mydeck.Add(gacharesulcards[i]);
            }

            showcards[i].GetComponent<CardsClass>().card = gacharesulcards[i];//ȭ�鿡 ���� ī�� ǥ��
        }

    }

   private CardInfo Gatcha()
    {//��í�� ���ϴ� �Լ�
        gacharesult = Random.Range(1,100);
        
    if(gacharesult <= gachainfo.RateTable[0]) 
        { 
        }else if(gachainfo.RateTable[0]< gacharesult && gacharesult <= gachainfo.RateTable[1])
        {
            return gachainfo.Commmon[Random.Range(0,gachainfo.Commmon.Length)];//Ŀ�� ��� ī��

        }
        else if (gachainfo.RateTable[1] < gacharesult && gacharesult <= gachainfo.RateTable[2])
        {
            return gachainfo.Epic[Random.Range(0, gachainfo.Epic.Length)];//���� ��� ī��

        }
        else if (gachainfo.RateTable[2] < gacharesult && gacharesult <= gachainfo.RateTable[3])
        {
            return gachainfo.Unique[Random.Range(0, gachainfo.Unique.Length)];//����ũ ��� ī��

        }
        else
        {
            return gachainfo.Legendary[Random.Range(0, gachainfo.Legendary.Length)];//������ ��� ī��
        }

        return gachainfo.Commmon[Random.Range(0, gachainfo.Commmon.Length)];
    }


    string BitArrayToString(BitArray bitArray)//��Ʈ��̸� �ؽ�Ʈ�� ǥ���� �� �ֵ������ִ� �Լ�
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < bitArray.Count; i++)
        {
            // �� ��Ʈ ���� 1 �Ǵ� 0���� ��ȯ�Ͽ� ���ڿ��� �߰�
            sb.Append(bitArray[i] ? "1" : "0");
        }

        return sb.ToString();
    }

    

   


}
