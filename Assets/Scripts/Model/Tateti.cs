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
    GamePlayer gamePlayer1 = new GamePlayer();
    GamePlayer gamePlayer2 = new GamePlayer();

    public  Tateti()
    {
        gamePlayer1.NamePlayer = "Player1";
        gamePlayer2.NamePlayer = "Player2";
    }
    public void SavePlayerChoice(int positionInArray)
    {
        GamePlayer player = DetectPlayer(IsFirstPlayer);
        int[] positionInMatrix = coordinates.ObtainPositionInMatrix(positionInArray);
        coordinates.SavePositionInMatrix(player.NamePlayer, positionInMatrix);
        if(CheckIfIsTateti(coordinates.Matrix, player.NamePlayer))
        {
            Winner=player.NamePlayer;
            coordinates.CleanMatrix();
        } else ChangePlayer(IsFirstPlayer);
    }

    public GamePlayer DetectPlayer(bool isFirstPlayer)
    {
        if (isFirstPlayer)
        {
            return gamePlayer1;
        }
        else
        {
            return gamePlayer2;
        }
    }



    public void ChangePlayer(bool isFirstPlayer)
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
