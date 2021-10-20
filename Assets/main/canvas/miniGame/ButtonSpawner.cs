using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{

    
    public int buttonCount;
    public GameObject[] buttons;
    

    

    public void Spawner()
    {
        if (buttonCount != 0)
        {
            gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
            Instantiate(buttons[Random.Range(0, 3)], Vector3.zero, Quaternion.identity, gameObject.transform);
            buttonCount--;
        }
        else
        {
            Debug.Log("u won");
            Destroy(gameObject);
            
        }

        
        
    }
}
