using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{

    
    public int buttonCount;
    public GameObject[] buttons;
    private GameObject gameController;
    public int rewardForWin;


    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

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
            WinGame(rewardForWin);
            Destroy(gameObject);
            
        }

        
        
    }

    public void WinGame(int oil)
    {
        gameController.GetComponent<GameController>().Win(oil);
        
    }
}
