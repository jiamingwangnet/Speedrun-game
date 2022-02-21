using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance 
    { 
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }

            return instance;
        } 
    }

    private Timer timer;

    public int NextScene { get; private set; } = 1;
    public TimeData Time { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        timer = FindObjectOfType<Timer>();
    }

    public void NextGame()
    {
        Time = timer.TimerData;
        SceneManager.LoadScene(NextScene);
        SceneManager.sceneLoaded += OnSceneLoad;
        NextScene++;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Player otherPlayer = FindObjectOfType<Player>();
        Destroy(otherPlayer.gameObject);
        timer = FindObjectOfType<Timer>();
        timer.DoNotSetTime = true;
        timer.TimerData = Time;
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
}
