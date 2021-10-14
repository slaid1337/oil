using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketController : MonoBehaviour
{
    public Image market;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            market.gameObject.SetActive(true);
        }
        Debug.Log("34123");
    }

    public void MarketOff()
    {
        market.gameObject.SetActive(false);
    }

}
