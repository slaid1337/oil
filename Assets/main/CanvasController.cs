using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Image market;
    public Image map;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag == "market")
        {
            market.gameObject.SetActive(true);
        }

        else if (other.tag == "Player" && gameObject.tag == "map")
        {
            map.gameObject.SetActive(true);
        }
    }

    public void MarketOff()
    {
        market.gameObject.SetActive(false);
    }

    public void Mapoff()
    {
        map.gameObject.SetActive(false);
    }

}
