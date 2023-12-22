using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    //?????? ????????
    public GameObject Fire;
    public GameObject Ground;
    public GameObject Metal;
    //??????1 ??????????
    public Transform Player1Spown;

    //???????? ?????? ????
    public int Player1CharacterType = 0;

    public Slider slider1;

    private void Awake()
    {
        Player1CharacterType = SendInformation.Player1CharcterType;

        if (Player1CharacterType == 1)
        {
            Instantiate(Fire, Player1Spown);
            //slider1.value = GetComponent<FireKight>().Health / 100;
        }
        if (Player1CharacterType == 2)
        {
            Instantiate(Ground, Player1Spown);
            //slider1.value = GetComponent<GroundMonk>().Health / 100;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        

    }

}
