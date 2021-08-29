using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tateti 
{
    private string[,] matrix = new string[3, 3];
    public string[,] Matrix { get => matrix; set => matrix = value; }

    private int size = 3;
    private bool isPlayer1=true;
    public bool IsFirstPlayer { get => isPlayer1; set => isPlayer1 = value; }

    public void SaveUserChoice(int positionInArray)
    {
        string player = SavePlayer(IsFirstPlayer);
        int[] positionInMatrix = SetPositionInMatrix(positionInArray);
        SaveCrossInMatrix(player, positionInMatrix);
        ChangeUser(IsFirstPlayer);
    }


    public string SavePlayer(bool isFirstPlayer)
    {
        if (isFirstPlayer == true)
        {
            return "Player1";
        }
        else
        {
            return "Player2";
        }
    }

    public int[] SetPositionInMatrix(int positionInArray)
    {
        int x = GetXPosition(positionInArray);
        int y = GETYPosition(positionInArray);
        int[] positionInMatrix = { x, y };
        return positionInMatrix;
    }

    private int GetXPosition(int positionInArray)
    {
        return positionInArray % size;
    }
    private int GETYPosition(int positionInArray)
    {
        return positionInArray / size;
    }
    public void ChangeUser(bool isFirstPlayer)
    {
        if (isFirstPlayer == true)
        {
            IsFirstPlayer = false;
        }
        else
        {
            IsFirstPlayer = true;
        }
    }

    public void SaveCrossInMatrix(string player, int[] positionInMatrix)
    {
        Matrix[positionInMatrix[0], positionInMatrix[1]] = player;
    }

    public bool CheckIfPositionIsBusy(string busy, int position)
    {

        return true;
    }
    //private int GetIndexFromCoordinates(int x, int y)
    //{
    //    return x + y * size;
    //}

}
