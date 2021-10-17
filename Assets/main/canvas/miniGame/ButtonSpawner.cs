using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{

    private Vector3 spawnPosition;
    public GameObject miniButton;
    public int buttonCount;

    private void Awake()
    {

        gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
        Instantiate(miniButton, Vector3.zero, Quaternion.identity, gameObject.transform);
        

        
    }
}
