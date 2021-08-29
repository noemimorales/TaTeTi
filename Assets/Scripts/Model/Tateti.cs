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
    private bool Win = false;
    public string Winner { get; set; }

    internal void CleanMatrix()
    {
        for (int column = 0; column < Matrix.GetLength(1); column++)
        {
            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                Matrix[row, column] = null;
            }
        }
        Winner = null;

    }

    public void SaveUserChoice(int positionInArray)
    {
        string player = namePlayer(IsFirstPlayer);
        int[] positionInMatrix = SetPositionInMatrix(positionInArray);
        SaveCrossInMatrix(player, positionInMatrix);
        if(CheckIfIsTateti(Matrix, player))
        {
            Winner=player;
        } else ChangeUser(IsFirstPlayer);
    }

    public string namePlayer(bool isFirstPlayer)
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

    public bool CheckIfIsTateti(string[,] matrix, string player)
    {
        string playerPositions = GetPlayerPositions(matrix, player);
        List<string> combinationsToWin = new List<string>
        {
            "012",
            "345",
            "678",
            "036",
            "147",
            "258",
            "048",
            "246"
        };
        char[] playerSelections = playerPositions.ToCharArray();
        SearchCoincidens(combinationsToWin, playerSelections);
        return Win;
    }

    private void SearchCoincidens(List<string> combinationsToWin, char[] playerSelections)
    {
        int sumOfCoincidens;
        foreach (string combination in combinationsToWin)
        {
            char[] combinations = combination.ToCharArray();
            sumOfCoincidens = 0;
            foreach (char charToFind in combinations)
            {
                foreach (char charInPlayerSelection in playerSelections)
                {
                    if (charToFind == charInPlayerSelection) sumOfCoincidens++;
                }
            }
            if (sumOfCoincidens == 3)
            {
                Win = true;
                break;
            }
        }
    }

    private string GetPlayerPositions(string[,] matrix, string player)
    {
        string playerPositions = "";
        for (int column = 0; column < matrix.GetLength(1); column++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, column] == player)
                {
                    playerPositions += GetIndexFromCoordinates(row, column).ToString();
                }
            }
        }
        return playerPositions;
    }


    private int GetIndexFromCoordinates(int x, int y)
    {
        return x + y * size;
    }

}
