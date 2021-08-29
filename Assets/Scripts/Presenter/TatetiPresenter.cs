using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TatetiPresenter
{
    private ITatetiView tatetiView;
    private Tateti tateti = new Tateti();



    public void Initialize(ITatetiView tatetiView)
    {
        this.tatetiView = tatetiView;
        tatetiView.Initialize(this);
        tateti.IsFirstPlayer = true;
    }

    public void SaveUserChoice(int positionInArray)
    {
        tateti.SaveUserChoice(positionInArray);
    }

    public bool IdentifyPlayer()
    {
        return tateti.IsFirstPlayer;
    }
}
