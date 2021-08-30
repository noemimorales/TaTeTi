using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TatetiView : MonoBehaviour, ITatetiView
{
    private TatetiPresenter tatetiPresenter = new TatetiPresenter();
    private List<ButtonView> buttonsInGrid;

    [SerializeField] public Button playAgainButton;
    [SerializeField] public TMP_Text player;
    [SerializeField] private TMP_Text winPlayer;
    [SerializeField] private Transform buttonsContainer;
    [SerializeField] private ButtonView buttonPrefab;

    private string actualPlayer;
    private void Start()
    {
        buttonsInGrid = new List<ButtonView>(buttonsContainer.GetComponentsInChildren<ButtonView>());
        tatetiPresenter.Initialize(this);
        playAgainButton.gameObject.SetActive(false);
        playAgainButton.onClick.AddListener(CleanGame);
        actualPlayer = IdentifyPlayerInView();
        player.text = actualPlayer;
        DetectButtonClick();
    }

    public void InstantiateButtons(List<string> buttons)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttonsInGrid.Count < i)
            {
                buttonsInGrid.Add(Instantiate(buttonPrefab, buttonsContainer));
            }
            else
            {
                buttonsInGrid[i].gameObject.SetActive(true);
            }
            buttonsInGrid[i].Init();
        }
    }
    private void DetectButtonClick()
    {
        for (int i = 0; i < buttonsInGrid.Count; i++)
        {
            ButtonAction(i);
        }
    }

    public void ButtonAction(int positionInGame)
    {
        buttonsInGrid[positionInGame].selectedPosition.onClick.AddListener(() =>
        {
            buttonsInGrid[positionInGame].SetImageToButton(IdentifyPlayerInView());
            DetectIsThereIsAWinner(positionInGame);
        });
    }

  
    public void DetectIsThereIsAWinner(int positionInGame)
    {
        if (tatetiPresenter.SaveUserChoice(positionInGame) != null)
        {
            playAgainButton.gameObject.SetActive(true);
        }
        actualPlayer = IdentifyPlayerInView();
        player.text = actualPlayer;
    }

    public string IdentifyPlayerInView()
    {
        if (tatetiPresenter.IdentifyPlayer())
        {
            return "Player1";
        }
        else
        {
            return "Player2";
        }
    }


    private void CleanGame()
    {
        tatetiPresenter.Initialize(this);
        winPlayer.text = "";
        tatetiPresenter.RestartGame();
        playAgainButton.gameObject.SetActive(false);

    }

    public void Initialize(TatetiPresenter tatetiPresenter)
    {
        this.tatetiPresenter = tatetiPresenter;
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
