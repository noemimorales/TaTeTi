using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tateti 
{

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

    Coordinates coordinates = new Coordinates();
    public void SaveUserChoice(int positionInArray)
    {
        string player = PutNamePlayer(IsFirstPlayer);
        int[] positionInMatrix = coordinates.ObtainPositionInMatrix(positionInArray);
        coordinates.SavePositionInMatrix(player, positionInMatrix);
        if(CheckIfIsTateti(coordinates.Matrix, player))
        {
            Winner=player;
            coordinates.CleanMatrix();
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



    public void ChangeUser(bool isFirstPlayer)
    {
        IsFirstPlayer = !isFirstPlayer;
    }



    public bool CheckIfIsTateti(string[,] matrix, string player)
    {
        string playedPositionsByPlayer = coordinates.GetPlayerPositions(matrix, player);
        char[] listOfPlayedPositionsByPlayer = playedPositionsByPlayer.ToCharArray();
        SearchCoincidens(winCombinations, listOfPlayedPositionsByPlayer);
        return Win;
    }

    public void SearchCoincidens(List<string> combinationsToWin, char[] playerSelections)
    {
        int sumOfCoincidens = 0;
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

    public void CleanWinner()
    {
        Winner = null;
        Win = false;
    }
}
