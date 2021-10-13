using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public int sceneIndex;

    void Start()
    {
        StartCoroutine(LoadScene(sceneIndex));
    }

    IEnumerator LoadScene (int sI)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sI);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }

    
}
