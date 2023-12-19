using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Player1Control : MonoBehaviour
{
    //입력_움직임
    float playerInput = 0f;

    //Fire-수치
    float Fire_MaxSpeed = 5f;

    //Ground-수치
    float Ground_MaxSpeed = 7f;

    //Metal-수치
    float Metal_MaxSpeed = 6.5f;

    //플레이어2 캐릭터 선택
    public int Player1CharacterType = 0;
    //캐릭터 가져오기
    public GameObject Fire;
    public GameObject Ground;
    public GameObject Metal;

    //캐릭터 rigid 가져오기
    Rigidbody2D rigid;
    Rigidbody2D Fire_rigid;
    Rigidbody2D Ground_rigid;
    Rigidbody2D Metal_rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Fire_rigid = Fire.GetComponent<Rigidbody2D>();
        Ground_rigid = Ground.GetComponent<Rigidbody2D>();
        Metal_rigid = Metal.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //기본 키 입력
        if (Input.GetKeyDown(KeyCode.A))
            playerInput = -1;
        else if (Input.GetKeyDown(KeyCode.D))
            playerInput = 1;

        //Fire 캐릭터
        if (Player1CharacterType == 1)
        {
            //기본이동,최고속도
            Fire_rigid.AddForce(Vector2.right * playerInput, ForceMode2D.Impulse);
            if (Fire_rigid.velocity.x > Fire_MaxSpeed)//왼쪽 MaxSpeed
                Fire_rigid.velocity = new Vector2(Fire_MaxSpeed, Fire_rigid.velocity.y);
            else if (Fire_rigid.velocity.x < Fire_MaxSpeed * (-1))//오른쪽 MaxSpeed
                Fire_rigid.velocity = new Vector2(Fire_MaxSpeed * (-1), Fire_rigid.velocity.y);

            //애니메이션
            if (playerInput != 0)
            {

            }

        }
        //Ground 캐릭터
        else if (Player1CharacterType == 2)
        {
            //기본이동,최고속도
            Ground_rigid.AddForce(Vector2.right * playerInput, ForceMode2D.Impulse);
            if (Ground_rigid.velocity.x > Ground_MaxSpeed)//왼쪽 MaxSpeed
                Ground_rigid.velocity = new Vector2(Ground_MaxSpeed, Ground_rigid.velocity.y);
            else if (Ground_rigid.velocity.x < Ground_MaxSpeed * (-1))//오른쪽 MaxSpeed
                Ground_rigid.velocity = new Vector2(Ground_MaxSpeed * (-1), Ground_rigid.velocity.y);
        }
        //Metal 캐릭터 
        else if (Player1CharacterType == 3)
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
