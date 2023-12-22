using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpControler : MonoBehaviour
{
    [SerializeField]
    public Slider slider1;
    [SerializeField] 
    public Slider slider2;

    int Player1Type;
    int Player2Type;

    float Player1Hp=100;
    float Player2Hp=100;

    private GameObject p1;
    private GameObject p2;

    private void Awake()
    {
       
        Player1Type = SendInformation.Player1CharcterType;
        Player2Type = SendInformation.Player2CharcterType;

        
        
    }

    private void Start()
    {
        if (Player1Type == 1)
        {
            p1 = GameObject.FindWithTag("Player1_Fire");
        }
        else if (Player1Type == 2)
        {
            p1 = GameObject.FindWithTag("Player1_Ground");
        }

        if (Player2Type == 1)
        {
            p2 = GameObject.FindWithTag("Player2_Fire");
        }
        else if (Player2Type == 2)
        {
            p2 = GameObject.FindWithTag("Player2_Ground");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Type == 1)
        {
            slider1.value = p1.GetComponent<FireKight>().Health/100;
        }
        else if (Player1Type == 2)
        {
            slider1.value = p1.GetComponent<GroundMonk>().Health/100;
        }

        if (Player2Type == 1)
        {
            slider2.value = p2.GetComponent<FireKight2>().Health/100;
        }
        else if (Player2Type == 2)
        {
            slider2.value = p2.GetComponent<GroundMonk2>().Health/100;
        }
    }
    
    
}
