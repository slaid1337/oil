using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Miner : MonoBehaviour
{
    public GameObject playButtonPref;
    private GameObject playButtonObject;
    public Image miniGame;
    public GameObject canvas;
    private Button playButton;
    public int countButtons;
    public int RewardForWin;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        playButtonObject = GameObject.FindGameObjectWithTag("playButton");
        playButton = playButtonObject.GetComponent<Button>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playButton.GetComponent<Image>().enabled = true;
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(delegate () { MiniGameStart(); });
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playButton.GetComponent<Image>().enabled = false;
        }
    }

    public void MiniGameOff()
    {
        playButton.gameObject.SetActive(false);
    }

    public void MiniGameStart()
    {
        Instantiate(miniGame, Vector3.zero, Quaternion.identity, canvas.transform);
        ButtonSpawner btn= GameObject.FindGameObjectWithTag("miniGame").GetComponent<ButtonSpawner>();
        btn.buttonCount = countButtons;
        btn.Spawner();
        btn.rewardForWin = RewardForWin;
        playButton.GetComponent<Image>().enabled = false;
    }

    
}
