using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameButtons : MonoBehaviour
{

    public Image circle;
    private float value = 0f;
    public float speed = 0.5f;
    private Vector2 spawnPosition;
    private float posHorizontal;
    private float posVertical;

    private void Awake()
    {
        posHorizontal = gameObject.transform.parent.GetComponent<RectTransform>().sizeDelta.x / 2;
        posVertical = gameObject.transform.parent.GetComponent<RectTransform>().sizeDelta.y / 2;

        spawnPosition = new Vector3(Random.Range(-posHorizontal, posHorizontal), Random.Range(-posVertical, posVertical));

        gameObject.GetComponent<RectTransform>().localPosition = spawnPosition;
    }

    private void Update()
    {
        CircleCloser();
    }

    public void CircleCloser()
    {
        circle.rectTransform.sizeDelta = Vector2.Lerp(new Vector2 (250f,250f) , new Vector2(130f,130f),value);
        value += Time.deltaTime * speed;
    }

    public void PointUp()
    {
        gameObject.transform.parent.GetComponent<ButtonSpawner>().Spawner();
        Destroy(gameObject);
    }
}
