using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        StartCoroutine(FindPlayer());
    }

    IEnumerator FindPlayer()
    {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("DemoScene");
        while (!asyncOp.isDone){
            yield return null;
        }
        GameObject playerObj = GameObject.Find("Player");
        Debug.Log(playerObj);
    }

    public void StartCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
