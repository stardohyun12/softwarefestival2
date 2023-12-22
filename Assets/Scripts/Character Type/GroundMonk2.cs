using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMonk2 : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rigid;
    int PlayID = 0;

    public float MaxSpeed = 6;
    float h = 0f;

    public float Health = 100;

    public Transform pos;
    public Vector2 boxSize;

    public Transform pos2;
    public Vector2 boxSize2;


    bool isAttacking;

    float Satkcooltime=0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PlayerInput();
        AttakInput();
        Run();
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
            if (Satkcooltime <= 0)
            {
                SpAtack();
                Satkcooltime = 3f;
            }
            else
            {

            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {

        }
    }


    void Run()
    {
        if (rigid.velocity.x != 0)
        {
            anim.SetBool("Ground_IsRuning", true);
        }
        else if (rigid.velocity.x == 0)
        {
            anim.SetBool("Ground_IsRuning", false);
        }
    }
    void ComboAtak()
    {
        anim.SetTrigger("Ground_ComboAtk");
        Invoke("AttackRagetrue", 0.1f);
        Invoke("AttackRangeflse", 0.3f);
        rigid.velocity = new Vector2(0f, rigid.velocity.y);
    }

    void SpAtack()
    {
        anim.SetTrigger("Ground_Spatk");
        Invoke("AttackRangetrue2", 1f);
        Invoke("AttackRangeflse2", 2f);
    }

    void AttackRange(bool isAttack)
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player1_Fire" && isAttacking == false)
            {
                collider.GetComponent<FireKight>().TakeDamage(4f);
                isAttacking = true;
                Invoke("IsAttackingfalse", 0.5f);

            }
            else if (collider.tag == "Player1_Ground" && isAttacking == false)
            {
                collider.GetComponent<GroundMonk>().TakeDamage(4f);
                isAttacking = true;
                Invoke("IsAttackingfalse", 0.5f);
            }
        }
    }
    void AttackRangeflse()
    {
        AttackRange(false);
    }

    void Attack2()
    {
        AttackRange2(true);
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
                Invoke("IsAttackingfalse", 0.5f);

            }
            else if (collider.tag == "Player1_Ground" && isAttacking == false)
            {
                collider.GetComponent<GroundMonk>().TakeDamage(7f);
                isAttacking = true;
                Invoke("IsAttackingfalse", 0.5f);
            }
        }
    }


    void IsAttackingfalse()
    {
        isAttacking = false;
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
        anim.SetTrigger("Ground_Takehit");
        Health = Health - damage;
    }

    void AttackRagetrue()
    {
        AttackRange(true);
    }

    void AttackRangetrue2()
    {
        AttackRange2(true);
    }

    








    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
        Gizmos.DrawWireCube(pos2.position, boxSize2);
    }

}