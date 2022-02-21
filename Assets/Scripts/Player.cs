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

    public int NextScene { get; private set; } = 1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NextGame()
    {
        SceneManager.LoadScene(NextScene);
        NextScene++;
    }
}
