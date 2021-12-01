using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == other.tag)
        {
            other.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;
            other.GetComponent<BlocksDrag>().draggable = false;
            RobotConstructorController rc = gameObject.transform.parent.GetComponent<RobotConstructorController>();
            rc.pieces[rc.counter] = other.gameObject;
            rc.counter++;
            rc.Winning();
        }
    }
}
