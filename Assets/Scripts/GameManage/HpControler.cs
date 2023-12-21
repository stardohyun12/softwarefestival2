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

    private void Awake()
    {
        slider1 = GetComponent<Slider>();
        slider2 = GetComponent<Slider>();
        Player1Type = SendInformation.Player1CharcterType;
        Player2Type = SendInformation.Player2CharcterType;

        if(Player1Type == 1)
        {
            slider1.value = GetComponent<FireKight>().Health /100; 
        }
        else if(Player1Type == 2) 
        {
            slider1.value = GetComponent<GroundMonk>().Health / 100;
        }

        if(Player2Type ==1)
        {
            slider2.value = GetComponent<FireKight>().Health / 100;
        }
        else if (Player2Type == 2) 
        {
            slider2.value= GetComponent<GroundMonk>().Health / 100;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Type == 1)
        {
            slider1.value = GetComponent<FireKight>().Health / 100;
        }
        else if (Player1Type == 2)
        {
            slider1.value = GetComponent<GroundMonk>().Health / 100;
        }

        if (Player2Type == 1)
        {
            slider2.value = GetComponent<FireKight>().Health / 100;
        }
        else if (Player2Type == 2)
        {
            slider2.value = GetComponent<GroundMonk>().Health / 100;
        }
    }
    
    
}
