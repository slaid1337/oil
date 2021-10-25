using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public int oil;
    public Text oilText;


    

    

    private void Start()
    {
        
        oilText.text = oil.ToString();
        
    }

    


    public void Win(int i)
    {
        oil += i;
        this.oilText.text = oil.ToString();
    }

    

}
