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
    [SerializeField] private Image[] crossImage;
    [SerializeField] private Image[] circleImage;
    [SerializeField] private TMP_Text player;
    [SerializeField] private TMP_Text winPlayer;

    private TatetiPresenter tatetiPresenter;

    private void Start()
    {
        tatetiPresenter = new TatetiPresenter();
        tatetiPresenter.Initialize(this);
        for (int i = 0; i < inputButtons.Length; i++)
        {
            crossImage[i].gameObject.SetActive(false);
            circleImage[i].gameObject.SetActive(false);
        }
        playAgainButton.gameObject.SetActive(false);
        DetectButtonClick();
        playAgainButton.onClick.AddListener(CleanGame);

    }

    private void CleanGame()
    {
        tatetiPresenter = new TatetiPresenter();
        tatetiPresenter.Initialize(this);
        for (int i = 0; i < inputButtons.Length; i++)
        {
            crossImage[i].gameObject.SetActive(false);
            circleImage[i].gameObject.SetActive(false);
        }
        winPlayer.text = "";
        tatetiPresenter.RestartGame();
        playAgainButton.gameObject.SetActive(false);

    }

    public void Initialize(TatetiPresenter tatetiPresenter)
    {
        this.tatetiPresenter = tatetiPresenter;
    }
    private void DetectButtonClick()
    {
        for (int i = 0; i < inputButtons.Length; i++)
        {
            ButtonAction(i);
        }
    }

    private void ButtonAction(int positionInArray)
    {
        inputButtons[positionInArray].onClick.AddListener(() =>
        {
            SetImageToButton(positionInArray);
            DetectIsThereIsAWinner(positionInArray);
            IdentifyPlayerInView();
        });
    }

    private void SetImageToButton(int positionInArray)
    {
        if (tatetiPresenter.IdentifyPlayer())
        {
            crossImage[positionInArray].gameObject.SetActive(true);
        }
        else
        {
            circleImage[positionInArray].gameObject.SetActive(true);
        }
    }

    private void DetectIsThereIsAWinner(int positionInArray)
    {
        if (tatetiPresenter.SaveUserChoice(positionInArray) != null)
        {
            playAgainButton.gameObject.SetActive(true);

        }
    }

    private void IdentifyPlayerInView()
    {
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
        playAgainButton.gameObject.SetActive(true);
    }
}
