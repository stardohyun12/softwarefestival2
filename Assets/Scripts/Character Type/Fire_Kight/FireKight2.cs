using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FireKight2 : MonoBehaviour
{
    //???????? ????
    int PlayID = 0;
    //????????
    float h = 0f;
    //????
    public float MaxSpeed = 5.5f;

    public Animator anim;
    public Rigidbody2D rigid;

    //Attack CoolTime
    private float timeBtwAttak;
    public float startTimeBtwAttack;



    //Attack Arange
    

    SpriteRenderer render;


    public int damage;

    public Transform pos;
    public Vector2 boxSize;

    public Transform pos2;
    public Vector2 boxSize2;

    public float Health = 100;


    bool isAttacking;

    float Satkcooltime = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        isAttacking = false;

    }


    // Update is called once per frame
    void Update()
    {
        Move();
        AttakInput();
        Run();
        PlayerInput();

        Satkcooltime -= Time.deltaTime;








    }


    void Move()
    {
        //Move
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (rigid.velocity.x > MaxSpeed)//???? MaxSpeed
            rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < MaxSpeed * (-1))//?????? MaxSpeed
            rigid.velocity = new Vector2(MaxSpeed * (-1), rigid.velocity.y);
        //????????
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            h = 0;


            rigid.velocity = new Vector2(0f, rigid.velocity.y);

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            h = 0;

            rigid.velocity = new Vector2(0f, rigid.velocity.y);
        }
    }
    void PlayerInput()
    {   
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                h = -1;
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                h = 1;
        
    }

    void AttakInput()
    {
        //????
        if (Input.GetKeyDown(KeyCode.H))
        {
            ComboAtak();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            Atk2();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (Satkcooltime <= 0)
            {
                SpAtk();
                Satkcooltime = 3f;
            }
            else
            {

            }
            
        }
    }

    void Run()
    {
        if (rigid.velocity.x != 0)
        {
            anim.SetBool("Fire_IsRuning", true);
        }
        else if (rigid.velocity.x == 0)
        {
            anim.SetBool("Fire_IsRuning", false);
        }
    }
    void ComboAtak()
    {
        Debug.Log("1");
        anim.SetTrigger("Fire_ComboAtk");
        Invoke("AttackRangetrue", 0.3f);
        Invoke("AttackRangeflse", 0.6f);
        Debug.Log("1");
        rigid.velocity = new Vector2(0f, rigid.velocity.y);
    }
    void Atk2()
    {
        anim.SetTrigger("Fire_Atk2");
        
        Invoke("AttackRangetrue", 0.3f);
        Invoke("AttackRangeflse", 0.6f);
        rigid.velocity = new Vector2(0f, rigid.velocity.y);
    }
    void SpAtk()
    {
        
        anim.SetTrigger("Fire_SpAtk");
        Invoke("AttackRangetrue2", 0.9f);
        Invoke("AttackRangeflse2", 1.2f);
        rigid.velocity = new Vector2(0f, rigid.velocity.y);
    }

    

    void AttackRange(bool isAttack)
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player1_Fire" && isAttacking ==false)
            {
                collider.GetComponent<FireKight>().TakeDamage(4);
                isAttacking = true;
                Invoke("IsAttackingfalse", 0.5f);
            }
            else if (collider.tag == "Player1_Ground" && isAttacking == false)
            {
                collider.GetComponent<GroundMonk>().TakeDamage(4);
                isAttacking = true;
                Invoke("IsAttackingfalse", 0.5f);
            }
        }
    }
    
    void AttackRange2(bool isAttack)
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos2.position, boxSize2, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player1_Fire" && isAttacking == false)
            {
                collider.GetComponent<FireKight>().TakeDamage(7f);
                isAttacking = true;
                Invoke("IsAttackingfalse", 0.6f);

            }
            else if (collider.tag == "Player1_Ground" && isAttacking == false)
            {
                collider.GetComponent<GroundMonk>().TakeDamage(7f);
                isAttacking = true;
                Invoke("IsAttackingfalse", 0.6f);
            }
        }
    }

    void IsAttackingfalse()
    {
        isAttacking = false;
    }
    

    void AttackRangetrue()
    {
        AttackRange(true);
    }

    void AttackRangeflse()
    {
        AttackRange(false);
    }

    void AttackRangetrue2()
    {
        AttackRange2(true);
    }

    void AttackRangeflse2()
    {
        AttackRange2(false);
    }

    public void TakeDamage(float damage)
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        anim.SetTrigger("Fire_Takehit");
        Health = Health - damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
        Gizmos.DrawWireCube(pos2.position, boxSize2);
    }


}
