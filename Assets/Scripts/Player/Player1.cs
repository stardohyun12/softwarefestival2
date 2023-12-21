using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //캐릭터 가져오기
    public GameObject Fire;
    public GameObject Ground;
    public GameObject Metal;
    //플레이1 스폰포인트
    public Transform Player1Spown;

    //플레이어 캐릭터 선택
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
