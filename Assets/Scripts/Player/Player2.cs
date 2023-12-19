using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //캐릭터 가져오기
    public GameObject Fire;
    public GameObject Ground;
    public GameObject Metal;
    //플레이어2 스폰포인트
    public Transform Player2Spown;

    //캐릭터 rigid 가져오기
    Rigidbody2D rigid;
    Rigidbody2D Fire_rigid;
    Rigidbody2D Ground_rigid;
    Rigidbody2D Metal_rigid;

    //입력-움직임
    int playerInput = 0;

    //Fire-수치
    float Fire_MaxSpeed = 5f;

    //Ground-수치
    float Ground_MaxSpeed = 7f;

    //Metal-수치
    float Metal_MaxSpeed = 6.5f;

    //플레이어2 캐릭터 선택
    public int Player2CharacterType = 0;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Fire_rigid = Fire.GetComponent<Rigidbody2D>();
        Ground_rigid = Ground.GetComponent<Rigidbody2D>();
        Metal_rigid = Metal.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Player2CharacterType == 1)
        {
            Instantiate(Fire, Player2Spown);
        }
        if (Player2CharacterType == 2)
        {
            Instantiate(Ground, Player2Spown);
        }
        if (Player2CharacterType == 3)
        {
            Instantiate(Metal, Player2Spown);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //기본 키 입력
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            playerInput = -1;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            playerInput = 1;

        //Fire 캐릭터
        if (Player2CharacterType == 1)
        {
            //기본이동,최고속도
            Fire_rigid.AddForce(Vector2.right * playerInput, ForceMode2D.Impulse);
            if (Fire_rigid.velocity.x > Fire_MaxSpeed)//왼쪽 MaxSpeed
                Fire_rigid.velocity = new Vector2(Fire_MaxSpeed, Fire_rigid.velocity.y);
            else if (Fire_rigid.velocity.x < Fire_MaxSpeed * (-1))//오른쪽 MaxSpeed
                Fire_rigid.velocity = new Vector2(Fire_MaxSpeed * (-1), Fire_rigid.velocity.y);
        }


        //Ground 캐릭터
        else if (Player2CharacterType == 2)
        {
            //기본이동,최고속도
            Ground_rigid.AddForce(Vector2.right * playerInput, ForceMode2D.Impulse);
            if (Ground_rigid.velocity.x > Ground_MaxSpeed)//왼쪽 MaxSpeed
                Ground_rigid.velocity = new Vector2(Ground_MaxSpeed, Ground_rigid.velocity.y);
            else if (Ground_rigid.velocity.x < Ground_MaxSpeed * (-1))//오른쪽 MaxSpeed
                Ground_rigid.velocity = new Vector2(Ground_MaxSpeed * (-1), Ground_rigid.velocity.y);
        }


        //Metal 캐릭터 
        else if (Player2CharacterType == 3)
        {
            //기본이동,최고속도
            Metal_rigid.AddForce(Vector2.right * playerInput, ForceMode2D.Impulse);
            if (Metal_rigid.velocity.x > Ground_MaxSpeed)//왼쪽 MaxSpeed
                Metal_rigid.velocity = new Vector2(Ground_MaxSpeed, Metal_rigid.velocity.y);
            else if (Metal_rigid.velocity.x < Ground_MaxSpeed * (-1))//오른쪽 MaxSpeed
                Metal_rigid.velocity = new Vector2(Ground_MaxSpeed * (-1), Metal_rigid.velocity.y);
        }
    }
}
