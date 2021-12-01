using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotConstructorController : MonoBehaviour 
{
    public int piecesCount;
    public int counter;
    public GameObject[] pieces;
    public GameObject blocksPref;

    private void Start()
    {
        counter = 0;
        pieces = new GameObject[gameObject.transform.childCount];
        Instantiate(blocksPref, GameObject.FindGameObjectWithTag("Canvas").gameObject.transform);
    }

    public void Winning()
    {
        if (piecesCount == counter)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().robotStatus = true;
            for (int i = 0; i < pieces.Length; i++)
            {
                Destroy(pieces[i]);
            }
            Destroy(gameObject);
        }
        
    }
}
