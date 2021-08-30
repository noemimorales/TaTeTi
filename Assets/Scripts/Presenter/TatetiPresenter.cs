using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UnityEngine;

public class TatetiPresenter
{
    private ITatetiView tatetiView;
    private Tateti tateti = new Tateti();

    string tatetiWinner=null;
    
    int counterOfPlayedPositions = 0;
    List<string> buttons = new List<string>
    {
        "TopLeft",
        "TopCenter",
        "TopRight",
        "MiddleLeft",
        "MiddleCenter",
        "MiddleRight",
        "BottomLeft",
        "BottomCenter",
        "BottomRight"
    };

    public TatetiPresenter(TatetiView view)
    {
        tatetiView = view;
        tatetiView.DidOnLoad += Load;
        tatetiView.DidOnDestroy += OnDestroy;
    }

    private void OnDestroy()
    {
        tatetiView.DidOnLoad -= Load;
        tatetiView.DidOnDestroy -= OnDestroy;
    }

    public void ListenPlay()
    {
        if (SaveUserChoice(positionInGame) != null)
        {
            tatetiView.EnablePlayAgain();
        }
    }


    private void Load()
    {
        tatetiView.InitializeTateti(this);
        tateti.CleanWinner();
        tatetiWinner = null;
        tatetiView.InstantiateButtons(buttons);
        tateti.IsFirstPlayer = true;
    }

    public string SaveUserChoice(int positionInGame)
    {
        tateti.SavePlayerChoice(positionInGame);
        if(tateti.Winner!=null)
        {
            tatetiView.SetWinner(tateti.Winner);
            tatetiWinner = tateti.Winner;
        }
        else if (counterOfPlayedPositions==8)
        {
            tatetiView.SetWinner("nobody");
            tatetiWinner = "nobody";
        }
        counterOfPlayedPositions++;
        return tatetiWinner;
    }

    public bool IdentifyPlayer()
    {
        return tateti.IsFirstPlayer;
    }

    public void RestartGame()
    {
        tateti.CleanWinner();
        tatetiWinner = null;
        tatetiView.InstantiateButtons(buttons);
        counterOfPlayedPositions = 0;
    }
}
