using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FireKight : MonoBehaviour
{
    //???????? ????
    int PlayID = 0;
    //????????
    float h =0f;
    //????
    public float MaxSpeed =5.5f;

    public Animator anim;
    public Rigidbody2D rigid;

    //Attack CoolTime
    private float timeBtwAttak;
    public float startTimeBtwAttack;

    //Attack Arange
    public BoxCollider2D Atk1;

    SpriteRenderer render;


    public int damage;

    public Transform pos;
    public Vector2 boxSize;

    public Transform pos2;
    public Vector2 boxSize2;

    public float Health = 100;

    bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();
        render=GetComponent<SpriteRenderer>();
        AttackRange(false);
        AttackRange2(false);
        isAttacking = false;
    }
   

    // Update is called once per frame
    void Update()
    {
        Move();
        AttakInput();
        Run();
        PlayerInput();


       
}


    void Move()
    {
        //Move
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (rigid.velocity.x > MaxSpeed)//???? MaxSpeed
            rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < MaxSpeed * (-1))//?????? MaxSpeed
            rigid.velocity = new Vector2(MaxSpeed * (-1), rigid.velocity.y);
        //속도조절
        if (Input.GetKeyUp(KeyCode.A))
        {
            h = 0;
            

            rigid.velocity = new Vector2(0f, rigid.velocity.y);

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            h = 0;

            rigid.velocity = new Vector2(0f, rigid.velocity.y);
        }
    }
    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            h = -1;
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            h = 1;    
        }


        
    }

    void AttakInput()
    {
        //????
        if (Input.GetKeyDown(KeyCode.M))
        {
            ComboAtak();
            


        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Atk2();
            
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            SpAtk();
            
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
        anim.SetTrigger("Fire_ComboAtk");
        
        Invoke("AttackRangetrue", 0.3f);
        Invoke("AttackRangeflse", 0.6f);
        
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
        Gizmos.DrawWireCube(pos2.position, boxSize2);
    }
    

    void AttackRange(bool isAttack)
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player2_Fire" && isAttacking == false)
            {
                collider.GetComponent<FireKight2>().TakeDamage(4);
                isAttacking = true;
                Invoke("IsAttackingfalse", 0.5f);

            }
            else if (collider.tag == "Player2_Ground" && isAttacking == false)
            {
                collider.GetComponent<GroundMonk2>().TakeDamage(4);
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
            if(collider.tag == "Player2_Fire" && isAttacking == false)
            {
                collider.GetComponent<FireKight2>().TakeDamage(7f);
                isAttacking = true;
                Invoke("IsAttackingfalse", 0.6f);

            }
            else if(collider.tag == "Player2_Ground" && isAttacking == false)
            {
                collider.GetComponent<GroundMonk2>().TakeDamage(7f);
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
        Health=Health - damage;
    }

   


}
