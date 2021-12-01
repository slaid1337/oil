using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingObject : MonoBehaviour
{
    private Renderer renderer;
    public bool isFading;
    private float transitionValue;
    private GameObject camera;
    private bool isDistance;
    private bool isSee;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        isFading = false;
        isDistance = true;
        isSee = false;
        transitionValue = 0;        
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        if (isFading)
        {
            renderer.material.SetColor("_Color", new Color(1, 1, 1, Mathf.Lerp(1,0,transitionValue)));
            transitionValue += Time.deltaTime;
            if (transitionValue >= 1)
            {
                transitionValue = 0;
                isFading = false;                
            }
        }
        else if (isSee)
        {
            renderer.material.SetColor("_Color", new Color(1, 1, 1, Mathf.Lerp(0, 1, transitionValue)));
            transitionValue += Time.deltaTime;
            if (transitionValue >= 1)
            {
                transitionValue = 0;
                isSee = false;
            }
        }
        if (Vector3.Distance(camera.transform.position, gameObject.transform.position) < 22f && isDistance){
            isFading = true;
            isDistance = false;
        }
        else if (Vector3.Distance(camera.transform.position, gameObject.transform.position) >= 22f && !isDistance)
        {
            isDistance = true;
            isSee = true;
        }
        
    }
}
