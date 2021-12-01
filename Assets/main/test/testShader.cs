using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testShader : MonoBehaviour
{
    private float value;

    private void Update()
    {
        value += Time.deltaTime / 4;
        GetComponent<Renderer>().material.SetTextureOffset("_DissolveMask", new Vector2(0,value));
    }
}
