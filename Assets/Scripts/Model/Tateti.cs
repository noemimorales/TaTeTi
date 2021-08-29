using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tateti 
{
    private const int SIZE = 3;

    private string[,] matrix = new string[SIZE, SIZE];
    public string[,] Matrix { get => matrix; set => matrix = value; }
    public bool IsFirstPlayer { get; set; }
    public string Winner { get; set; }
    public bool Win { get; set; }

    List<string> winCombinations = new List<string>
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
    public void CleanMatrix()
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
        string player = PutNamePlayer(IsFirstPlayer);
        int[] positionInMatrix = ObtainPositionInMatrix(positionInArray);
        SavePositionInMatrix(player, positionInMatrix);
        if(CheckIfIsTateti(Matrix, player))
        {
            Winner=player;
        } else ChangeUser(IsFirstPlayer);
    }

    public string PutNamePlayer(bool isFirstPlayer)
    {
        if (isFirstPlayer)
        {
            return "Player1";
        }
        else
        {
            return "Player2";
        }
    }

    public int[] ObtainPositionInMatrix(int positionInArray)
    {
        int x = GetXPosition(positionInArray);
        int y = GETYPosition(positionInArray);
        int[] positionInMatrix = { x, y };
        return positionInMatrix;
    }

    private int GetXPosition(int positionInArray)
    {
        return positionInArray % SIZE;
    }
    private int GETYPosition(int positionInArray)
    {
        return positionInArray / SIZE;
    }
    public void ChangeUser(bool isFirstPlayer)
    {
        IsFirstPlayer = !isFirstPlayer;
    }

    public void SavePositionInMatrix(string player, int[] positionInMatrix)
    {
        Matrix[positionInMatrix[0], positionInMatrix[1]] = player;
    }

    public bool CheckIfIsTateti(string[,] matrix, string player)
    {
        string playedPositionsByPlayer = GetPlayerPositions(matrix, player);
        char[] listOfPlayedPositionsByPlayer = playedPositionsByPlayer.ToCharArray();
        SearchCoincidens(winCombinations, listOfPlayedPositionsByPlayer);
        return Win;
    }

    public void SearchCoincidens(List<string> combinationsToWin, char[] playerSelections)
    {
        int sumOfCoincidens;
        foreach (string combinationToWin in combinationsToWin)
        {
            char[] listOfCombinationToWin = combinationToWin.ToCharArray();
            sumOfCoincidens = 0;
            foreach (char charToFind in listOfCombinationToWin)
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

    public string GetPlayerPositions(string[,] matrix, string player)
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
        return x + y * SIZE;
    }

}
