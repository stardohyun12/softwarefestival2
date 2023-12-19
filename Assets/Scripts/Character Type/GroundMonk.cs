using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMonk : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        void Ground_Run()
        {
            anim.GetBool("Ground_IsRuning");
        }
        void Ground_Atk1()
        {
            anim.SetTrigger("Ground_Atk1");
        }

    }


    void ComboAtack()
    {

    }
}
