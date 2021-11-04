using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotConstructorController : MonoBehaviour 
{
    public int piecesCount;
    public int counter;
    public GameObject[] pieces;

    private void Start()
    {
        counter = 0;
    }

    public void Winning()
    {
        if (piecesCount == counter)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                Destroy(pieces[i]);
            }
            Destroy(gameObject);
        }
    }
}
