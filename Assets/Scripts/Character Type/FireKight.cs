using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKight : MonoBehaviour
{
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
        void Fire_Run()
        {
            anim.GetBool("Fire_IsRuning");
        }
        void Fire_Atk1()
        {
            anim.SetTrigger("Fire_Atk1");
        }


    }
}
