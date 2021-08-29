using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TatetiPresenter
{
    private ITatetiView tatetiView;
    private Tateti tateti = new Tateti();
    private int size = 3;
    private bool isPlayer1;
    public bool ISPlayer1 { get => isPlayer1; set => isPlayer1 = value; }

    public void Initialize(ITatetiView tatetiView)
    {
        this.tatetiView = tatetiView;
        tatetiView.Initialize(this);
        ISPlayer1 = true;
    }


    public void SaveUserChoice(int positionInArray)
    {
        SetPositionInMatrix(positionInArray);
        ChangeUser();
    }

    public void ChangeUser()
    {
        if (ISPlayer1 == true)
        {
            ISPlayer1=false;
        }
        else
        {
            ISPlayer1 = true;
        }
    }

    public void SetPositionInMatrix(int positionInArray)
    {
        int x = GetXPosition(positionInArray);
        int y = GETYPosition(positionInArray);
        SaveCrossInMatrix(x,y);
    }
    private int GETYPosition(int positionInArray)
    {
        return positionInArray / size;
    }

    private int GetXPosition(int positionInArray)
    {
        return positionInArray % size;
    }
    private void SaveCrossInMatrix(int x, int y)
    {
        if (ISPlayer1 == true)
        {
            tateti.Matrix[x, y] = "Player1";
        }
        else
        {
            tateti.Matrix[x, y] = "Player2";
        }
    }
    private int GetIndexFromCoordinates(int x, int y)
    {
        return x + y * size;
    }

    //public void DrawResults()
    //{
    //    tatetiView.DrawCross(tateti.Cross);
    //    for (int i = 0; i < game.frames.Length; i++)
    //    {
    //        gameView.DrawFrame(i + 1, game.frames[i].Score, game.frames[i].Balls, game.frames[i].CurrentBall, game.frames[i].IsStrike, game.frames[i].IsSpare);
    //    }
    //}

}
