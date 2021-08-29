using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TatetiView : MonoBehaviour, ITatetiView
{
    [SerializeField] private Button[] inputButtons;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private GameObject[] crossImage;
    [SerializeField] private GameObject[] circleImage;
    [SerializeField] private TMP_Text player;
    [SerializeField] private TMP_Text winPlayer;

    private TatetiPresenter tatetiPresenter;
    private int positionInArray;

    private void Start()
    {
        tatetiPresenter = new TatetiPresenter();
        tatetiPresenter.Initialize(this);
        for (int i = 0; i < inputButtons.Length; i++)
        {
            crossImage[i].SetActive(false);
            circleImage[i].SetActive(false);
        }
        playAgainButton.enabled = false;
        SetInputAtions();
        playAgainButton.onClick.AddListener(CleanGame);

    }

    private void CleanGame()
    {
        tatetiPresenter = new TatetiPresenter();
        tatetiPresenter.Initialize(this);
        for (int i = 0; i < inputButtons.Length; i++)
        {
            crossImage[i].SetActive(false);
            circleImage[i].SetActive(false);
        }
        winPlayer.text = "";
        tatetiPresenter.RestartGame();
        playAgainButton.enabled = false;

    }

    public void Initialize(TatetiPresenter tatetiPresenter)
    {
        this.tatetiPresenter = tatetiPresenter;
    }
    private void SetInputAtions()
    {
       inputButtons[0].onClick.AddListener(() =>
        {
            positionInArray = 0;
            OnClickInput();
        });
        inputButtons[1].onClick.AddListener(() =>
        {
            positionInArray = 1;
            OnClickInput();
        });

        inputButtons[2].onClick.AddListener(() =>
        {
            positionInArray = 2;
            OnClickInput();
        });
        inputButtons[3].onClick.AddListener(() =>
        {
            positionInArray = 3;
            OnClickInput();
        });
        inputButtons[4].onClick.AddListener(() =>
        {
            positionInArray = 4;
            OnClickInput();
        });

        inputButtons[5].onClick.AddListener(() =>
        {
            positionInArray = 5;
            OnClickInput();
        });
        inputButtons[6].onClick.AddListener(() =>
        {
            positionInArray = 6;
            OnClickInput();
        });
        inputButtons[7].onClick.AddListener(() =>
        {
            positionInArray = 7;
            OnClickInput();
        });

        inputButtons[8].onClick.AddListener(() =>
        {
            positionInArray = 8;
            OnClickInput();
        });
    }

    private void OnClickInput()
    {
        if (tatetiPresenter.IdentifyPlayer())
        {
            crossImage[positionInArray].SetActive(true);
        }
        else
        {
            circleImage[positionInArray].SetActive(true);
        }

        if (tatetiPresenter.SaveUserChoice(positionInArray) != null)
        {
            playAgainButton.enabled = true;

        }
        if (tatetiPresenter.IdentifyPlayer())
        {
            player.text = "Player1";
        }
        else
            {
                player.text = "Player2";
            }

    }

    public void SetWinner(string winner)
    {
        if (winner == "nobody")
        {
            winPlayer.text = " NOBODY WIN!!!!!";
        }
        else
        {
            winPlayer.text = winner + " YOU WIN!!!!!";
        }
        playAgainButton.enabled = true;
    }
}
