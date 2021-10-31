using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretMiner : MonoBehaviour
{
    public GameObject playButtonPref;
    private GameObject playButtonObject;
    public Image miniGame;
    public GameObject canvas;
    private Button playButton;
    public int countButtons;
    public int RewardForWin;
    public bool findPlace;


    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        GetComponent<MeshRenderer>().enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && findPlace)
        {
            Instantiate(playButtonPref, Vector3.down, Quaternion.identity, canvas.transform);
            playButtonObject = GameObject.FindGameObjectWithTag("playButton");
            playButtonObject.GetComponent<RectTransform>().localPosition = new Vector2(0f, 20f);
            playButton = playButtonObject.GetComponent<Button>();
            playButton.onClick.AddListener(delegate () { MiniGameStart(); });

        }
        if (other.tag == "spider")
        {
            findPlace = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
            

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(playButtonObject);
        }
    }

    public void MiniGameOff()
    {
        playButton.gameObject.SetActive(false);
    }

    public void MiniGameStart()
    {
        Instantiate(miniGame, Vector3.zero, Quaternion.identity, canvas.transform);
        GameObject.FindGameObjectWithTag("miniGame").GetComponent<ButtonSpawner>().buttonCount = countButtons;
        GameObject.FindGameObjectWithTag("miniGame").GetComponent<ButtonSpawner>().Spawner();
        GameObject.FindGameObjectWithTag("miniGame").GetComponent<ButtonSpawner>().rewardForWin = RewardForWin;
        Destroy(playButtonObject);
    }
}
