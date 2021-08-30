using System;
using System.Collections.Generic;
using System.Drawing;
using DefaultNamespace;
using TMPro;
using UnityEngine.UI;

public class TatetiView : ITatetiView
{
    private List<ButtonView> buttonsInGrid;

    [SerializeField] public Button playAgainButton;
    [SerializeField] public TMP_Text player;
    [SerializeField] private TMP_Text winPlayer;
    [SerializeField] private Transform buttonsContainer;
    [SerializeField] private ButtonView buttonPrefab;
    public event Action DidOnLoad = () => { }; 
    public event Action DidOnDestroy = () => { }; 

    private string actualPlayer;

    void OnLoad()
    {
        DidOnLoad();
    }
    
    void OnDestroy()
    {
        DidOnDestroy();
    }

    private void Start()
    {
        buttonsInGrid = new List<ButtonView>(buttonsContainer.GetComponentsInChildren<ButtonView>());
        PresenterInitializer.Init(this);
        playAgainButton.gameObject.SetActive(false);
        playAgainButton.onClick.AddListener(CleanGame);
        actualPlayer = IdentifyPlayerInView();
        player.text = actualPlayer;
        DetectButtonClick();new Point(0,0)
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
            EnablePlayAgain();
        }
        actualPlayer = IdentifyPlayerInView();
        player.text = actualPlayer;
    }

    private void EnablePlayAgain()
    {
        playAgainButton.gameObject.SetActive(true);
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
        winPlayer.text = "";
        tatetiPresenter.RestartGame();
        playAgainButton.gameObject.SetActive(false);

    }

    public void InitializeTateti(TatetiPresenter tatetiPresenter)
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
