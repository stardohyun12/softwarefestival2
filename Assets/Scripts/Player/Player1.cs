using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //ĳ���� ��������
    public GameObject Fire;
    public GameObject Ground;
    public GameObject Metal;
    //�÷���1 ��������Ʈ
    public Transform Player1Spown;

    //�÷��̾� ĳ���� ����
    public int Player1CharacterType = 0;

    

    private void Awake()
    {


    }
    // Start is called before the first frame update
    void Start()
    {
        Player1CharacterType = SendInformation.Player1CharcterType;

        if (Player1CharacterType == 1)
        {
            Instantiate(Fire,Player1Spown);
        }
        if(Player1CharacterType == 2)
        {
            Instantiate(Ground, Player1Spown);
        }
        if(Player1CharacterType == 3) 
        {
            Instantiate(Metal, Player1Spown);
        }

    }

    // Update is called once per frame
    
}
