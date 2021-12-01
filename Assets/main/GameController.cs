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
    public bool barCharging;
    private Vector3 currentScale;
    private float value;

    public GameObject robotPref;
    public bool robotStatus;
    public GameObject[] miniGamePrefs;

    private GameObject vechicle;

    private void Start()
    {
        barCharging = false;
        Volume = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().bankVolume;
        vechicle = GameObject.FindGameObjectWithTag("Player");
        oilBar.GetComponent<RectTransform>().localScale = new Vector3(1,(oil / (Volume / 100)) / 100,1);
        value = 0;
        robotStatus = false;
        Screen.orientation = ScreenOrientation.Landscape;
    }

    private void Update()
    {

        if (barCharging)
        {

            if (oil >= Volume)
            {
                oil = Convert.ToInt32(Volume);
            }
            
            oilBar.GetComponent<RectTransform>().localScale = Vector3.Lerp(currentScale, new Vector3(1, (oil / (Volume / 100)) / 100, 1), value);
            value += Time.deltaTime * 0.5f;
            if (value >= 1)
            {
                barCharging = false;
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
        barCharging = true;
    }

    public void RobotActivation()
    {
        if (robotStatus)
        {
            Instantiate(robotPref,vechicle.transform.position + new Vector3(0,0,2f),Quaternion.identity);
            robotStatus = false;
        }
        else
        {
            Instantiate(miniGamePrefs[UnityEngine.Random.Range(0,miniGamePrefs.Length)],GameObject.FindGameObjectWithTag("Canvas").transform);
        }
    }

}
