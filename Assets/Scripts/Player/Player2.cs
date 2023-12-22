using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    //?????? ????????
    public GameObject Fire;
    public GameObject Ground;
    public GameObject Metal;
    //????????2 ??????????
    public Transform Player2Spown;

    //?????? rigid ????????

    public Slider slider2;



    //????????2 ?????? ????
    public int Player2CharacterType = 0;

    public void Awake()
    {
        Player2CharacterType = SendInformation.Player2CharcterType;



        if (Player2CharacterType == 1)
        {
            Instantiate(Fire, Player2Spown);
        }
        if (Player2CharacterType == 2)
        {
            Instantiate(Ground, Player2Spown);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
