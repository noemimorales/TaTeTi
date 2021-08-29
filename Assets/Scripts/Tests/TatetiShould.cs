using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TatetiShould
{
    Tateti tateti;
    [SetUp]
    public void Before()
    {
        tateti = new Tateti();
    }
    
    [Test]
    public void HasAThreeByThreeMatrix() 
    {
        //when
        string[,] expectedMatrix = new string[3, 3];
        string[,] resultMatrix = tateti.Matrix;

        //then
        Assert.AreEqual(expectedMatrix.GetLength(0), resultMatrix.GetLength(0));
        Assert.AreEqual(expectedMatrix.GetLength(1), resultMatrix.GetLength(1));
    }

    [TestCase("Player1",true)]
    [TestCase("Player2", false)]
    public void SavePlayer(string expectedPlayer, bool isPlayer1)
    {
        //Then
        Assert.AreEqual(expectedPlayer, tateti.PutNamePlayer(isPlayer1));
    }

    [TestCase(false, true)]
    [TestCase(true, false)]
    public void ChangePlayerAfterPlay(bool expectedPlayer, bool isPlayer1)
    {
        //given
        tateti.ChangeUser(isPlayer1);
        //Then
        Assert.AreEqual(expectedPlayer,tateti.IsFirstPlayer);
    }


    [TestCase(0, 0, 0)]
    [TestCase(1, 0, 1)]
    [TestCase(2, 0, 2)]
    [TestCase(0, 1, 3)]
    [TestCase(1, 1, 4)]
    [TestCase(2, 1, 5)]
    [TestCase(0, 2, 6)]
    [TestCase(1, 2, 7)]
    [TestCase(2, 2, 8)]

    public void ObtainPositionInMatrix(int x, int y, int position)
    {
        //given
        int[] positionInMatrix = { x, y };

        //when

        //Then
        Assert.AreEqual(positionInMatrix, tateti.ObtainPositionInMatrix(position));
    }

    [TestCase("Player1", 0, 0, 0)]
    [TestCase("Player1", 1, 0, 1)]
    [TestCase("Player1", 2, 0, 2)]
    [TestCase("Player1", 0, 1, 3)]
    [TestCase("Player1", 1, 1, 4)]
    [TestCase("Player1", 2, 1, 5)]
    [TestCase("Player1", 0, 2, 6)]
    [TestCase("Player1", 1, 2, 7)]
    [TestCase("Player1", 2, 2, 8)]

    public void SavePositionInMatrix(string player, int x, int y, int position)
    {
        //when
        tateti.SavePositionInMatrix(player, tateti.ObtainPositionInMatrix(position));

        //Then
        Assert.IsTrue(tateti.Matrix[x,y].Contains(player));
    }

    [Test]
    public void CheckIfIsTateti()
    {
        //given
        string player;

        //when
        player = "Player1";
        tateti.Matrix[0, 0] = player;
        tateti.Matrix[1, 0] = player;
        tateti.Matrix[2, 0] = player;

        //Then
        Assert.IsTrue(tateti.CheckIfIsTateti(tateti.Matrix,player));
    }

    [Test]
    public void SearchCoincidens()
    {
        //given
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

        //when
        char[] playerSelections = {'0','1','2'};
        tateti.SearchCoincidens(combinationsToWin, playerSelections);

        //Then
        Assert.AreEqual(true,tateti.Win);
    }

    [Test]
    public void GetPlayerPositions()
    {
        //given
        string player;
        string expectedPositions;

        //when
        player = "Player1";
        tateti.Matrix[0, 0] = player;
        tateti.Matrix[1, 0] = player;
        tateti.Matrix[2, 0] = player;
        expectedPositions = "012";

        //Then
        Assert.AreEqual(expectedPositions, tateti.GetPlayerPositions(tateti.Matrix, player));
    }
}
