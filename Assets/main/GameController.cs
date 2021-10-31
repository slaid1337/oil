using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public int oil;
    public int oldOil;
    public GameObject oilBar;
    public float Volume;
    public bool winning;
    private Vector3 currentScale;
    private float value;


    private void Start()
    {
        winning = false;
        Volume = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().bankVolume;
        oilBar.GetComponent<RectTransform>().localScale = new Vector3(1,(oil / (Volume / 100)) / 100,1);
        value = 0;
    }

    private void Update()
    {

        if (winning)
        {
            oilBar.GetComponent<RectTransform>().localScale = Vector3.Lerp(currentScale, new Vector3(1, (oil / (Volume / 100)) / 100, 1), value);
            value += Time.deltaTime * 0.5f;
            if ( value >= 1)
            {
                winning = false;
            }
        }
         
           
    }


    public void Win(int i)
    {
        oldOil += oil;
        oil += i;
        Volume = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().bankVolume;
        value = 0;
        currentScale = new Vector3(1, oilBar.GetComponent<RectTransform>().localScale.y, 1);
        winning = true;
    }

    

}
