using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKight : MonoBehaviour
{
    //???????? ????
    int PlayID = 0;
    //????????
    float h =0f;
    //????
    float MaxSpeed =5.5f;

    public Animator anim;
    public Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();

    }
   

    // Update is called once per frame
    void Update()
    {
        
        
            if (Input.GetKeyDown(KeyCode.A))
            {
                
                h = -1;
            }
                
            else if (Input.GetKeyDown(KeyCode.D))
            {
                h = 1;
                
            }
                
        
        else if(PlayID == 2) 
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                h = -1;
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                h = 1;
        }

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

        //????
        if (Input.GetKeyDown(KeyCode.M))
        {
            ComboAtak();

        }
        else if(Input.GetKeyDown(KeyCode.N)) 
        {
            Atk2();
        }
        else if(Input.GetKeyDown(KeyCode.B)) 
        {
            SpAtk();
        }

        if(rigid.velocity.x !=0 )
        {
            Run();
        }


    }

    void Run()
    {
        anim.GetBool("Fire_IsRuning");
    }
    void ComboAtak()
    {
        anim.SetTrigger("Fire_ComboAtk");
        rigid.velocity = new Vector2(0f, rigid.velocity.y);
    }
    void Atk2()
    {
        anim.SetTrigger("Fire_Atk2");
        rigid.velocity = new Vector2(0f, rigid.velocity.y);
    }
    void SpAtk()
    {
        anim.SetTrigger("Fire_SpAtk");
        rigid.velocity = new Vector2(0f, rigid.velocity.y);
    }



}
