using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Player1Control : MonoBehaviour
{
    //�Է�_������
    float playerInput = 0f;

    //Fire-��ġ
    float Fire_MaxSpeed = 5f;

    //Ground-��ġ
    float Ground_MaxSpeed = 7f;

    //Metal-��ġ
    float Metal_MaxSpeed = 6.5f;

    //�÷��̾�2 ĳ���� ����
    public int Player1CharacterType = 0;
    //ĳ���� ��������
    public GameObject Fire;
    public GameObject Ground;
    public GameObject Metal;

    //ĳ���� rigid ��������
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
        //�⺻ Ű �Է�
        if (Input.GetKeyDown(KeyCode.A))
            playerInput = -1;
        else if (Input.GetKeyDown(KeyCode.D))
            playerInput = 1;

        //Fire ĳ����
        if (Player1CharacterType == 1)
        {
            //�⺻�̵�,�ְ�ӵ�
            Fire_rigid.AddForce(Vector2.right * playerInput, ForceMode2D.Impulse);
            if (Fire_rigid.velocity.x > Fire_MaxSpeed)//���� MaxSpeed
                Fire_rigid.velocity = new Vector2(Fire_MaxSpeed, Fire_rigid.velocity.y);
            else if (Fire_rigid.velocity.x < Fire_MaxSpeed * (-1))//������ MaxSpeed
                Fire_rigid.velocity = new Vector2(Fire_MaxSpeed * (-1), Fire_rigid.velocity.y);

            //�ִϸ��̼�
            if (playerInput != 0)
            {

            }

        }
        //Ground ĳ����
        else if (Player1CharacterType == 2)
        {
            //�⺻�̵�,�ְ�ӵ�
            Ground_rigid.AddForce(Vector2.right * playerInput, ForceMode2D.Impulse);
            if (Ground_rigid.velocity.x > Ground_MaxSpeed)//���� MaxSpeed
                Ground_rigid.velocity = new Vector2(Ground_MaxSpeed, Ground_rigid.velocity.y);
            else if (Ground_rigid.velocity.x < Ground_MaxSpeed * (-1))//������ MaxSpeed
                Ground_rigid.velocity = new Vector2(Ground_MaxSpeed * (-1), Ground_rigid.velocity.y);
        }
        //Metal ĳ���� 
        else if (Player1CharacterType == 3)
        {
            //�⺻�̵�,�ְ�ӵ�
            Metal_rigid.AddForce(Vector2.right * playerInput, ForceMode2D.Impulse);
            if (Metal_rigid.velocity.x > Ground_MaxSpeed)//���� MaxSpeed
                Metal_rigid.velocity = new Vector2(Ground_MaxSpeed, Metal_rigid.velocity.y);
            else if (Metal_rigid.velocity.x < Ground_MaxSpeed * (-1))//������ MaxSpeed
                Metal_rigid.velocity = new Vector2(Ground_MaxSpeed * (-1), Metal_rigid.velocity.y);
        }


    }
}
