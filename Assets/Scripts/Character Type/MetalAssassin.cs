using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalAssassin : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        void Metal_Run()
        {
            anim.GetBool("Metal_IsRuning");
        }
        void Metal_Atk1()
        {
            anim.SetTrigger("Metal_Atk1");
        }
    }
}
