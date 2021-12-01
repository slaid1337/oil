using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectioinsGenerator : MonoBehaviour
{
    
    public GameObject place;

    private void Start()
    {
        gameObject.transform.LookAt(place.transform);
    }
}
