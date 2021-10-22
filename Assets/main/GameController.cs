using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public int oil;
    public Text oilText;

    public static GameController current;

    private void Start()
    {
        current = this;
        
        oilText.text = oil.ToString();
    }

    public event Action OnTrigger;

    public void OnTriigerEnterPoint()
    {
        if (OnTrigger != null)
        {
            OnTrigger();
        }
    }

}
