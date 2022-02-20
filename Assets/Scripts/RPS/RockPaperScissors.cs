using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPaperScissors : MonoBehaviour
{
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject paper;
    [SerializeField] private GameObject scissors;

    // where the things are placed
    [SerializeField] private Transform computerPos;
    [SerializeField] private Transform playerPos;

    [SerializeField] private GameObject winText;

    private enum RPS
    {
        Rock,
        Paper,
        Scissors
    }

    [SerializeField] private float playTimeout = 2f;
    private float nextPlay = 0f;
    private bool hasWon = false;

    // Update is called once per frame
    void Update()
    {       
        if (!hasWon)
        {
            if (Time.time >= nextPlay)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    PlayGame(RPS.Rock, ref hasWon);
                    nextPlay = Time.time + playTimeout;
                }
                else if (Input.GetKeyDown(KeyCode.P))
                {
                    PlayGame(RPS.Paper, ref hasWon);
                    nextPlay = Time.time + playTimeout;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    PlayGame(RPS.Scissors, ref hasWon);
                    nextPlay = Time.time + playTimeout;
                }
            }
        } 
        else
        {
            winText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Player.Instance.NextGame();
            }
        } 
    }

    private void PlayGame(RPS playerChosen, ref bool hasWon)
    {
        RPS comp = ComputerPlay();

        if(playerPos.childCount > 0 && computerPos.childCount > 0)
        {
            Destroy(playerPos.GetChild(0).gameObject);
            Destroy(computerPos.GetChild(0).gameObject);
        }

        Instantiate(ConvertToGameObject(playerChosen), playerPos);
        Instantiate(ConvertToGameObject(comp), computerPos);

        if(playerChosen == comp)
        {
            hasWon = false;   
        }
        else if(playerChosen == RPS.Rock)
        {
            if (comp == RPS.Paper)
            {
                hasWon = false;
            }
            else
            {
                hasWon = true;
            }
        }
        else if (playerChosen == RPS.Paper)
        {
            if (comp == RPS.Scissors)
            {
                hasWon = false;
            }
            else
            {
                hasWon = true;
            }
        }
        else if (playerChosen == RPS.Scissors)
        {
            if (comp == RPS.Rock)
            {
                hasWon = false;
            }
            else
            {
                hasWon = true;
            }
        }
    }

    private RPS ComputerPlay()
    {
        int computerChosen = Random.Range(0, 3);

        return (RPS)computerChosen;
    }

    private GameObject ConvertToGameObject(RPS play)
    {
        switch (play)
        {
            case RPS.Rock:
                return rock;
            case RPS.Paper:
                return paper;
            case RPS.Scissors:
                return scissors;
            default:
                return null;
        }
    }
}
