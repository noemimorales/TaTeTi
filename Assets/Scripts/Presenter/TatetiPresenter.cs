using System;
using System.Collections;
using System.Collections.Generic;
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

    public void Initialize(ITatetiView tatetiView)
    {
        this.tatetiView = tatetiView;
        tatetiView.Initialize(this);
        tateti.CleanMatrix();
        tatetiWinner = null;
        tatetiView.InstantiateButtons(buttons);
        tateti.IsFirstPlayer = true;
    }

    public string SaveUserChoice(int positionInGame)
    {
        tateti.SaveUserChoice(positionInGame);
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
        tateti.IsFirstPlayer = true;
        tateti.CleanMatrix();
        tatetiWinner = null;
        counterOfPlayedPositions = 0;
    }
}
