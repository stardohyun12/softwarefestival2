using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public InputField Player1;
    public InputField Player2;

    

    private void Start()
    {
        
    }

    public void OnClickStartButton()
    {


        SendInformation.Player1CharcterType = int.Parse(Player1.text);
        SendInformation.Player2CharcterType = int.Parse(Player2.text);
        Debug.Log(SendInformation.Player1CharcterType);

        Debug.Log(SendInformation.Player2CharcterType);
        SceneManager.LoadScene("Scene1");
        
        
    }

    
}
