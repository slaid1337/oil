using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireFluid : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Destroy(1.5f));
    }
    private void Update()
    {
        transform.position += transform.forward * 0.1f;
    }

    private IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
