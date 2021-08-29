using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TatetiShould
{
    [Test]
    public void HasAThreeByThreeMatrix() 
    {
        //given
        Tateti tateti = new Tateti();

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
        //given
        Tateti tateti = new Tateti();

        //Then
        Assert.AreEqual(expectedPlayer, tateti.namePlayer(isPlayer1));
    }

    [TestCase(false, true)]
    [TestCase(true, false)]
    public void ChangePlayerAfterPlay(bool expectedPlayer, bool isPlayer1)
    {
        //given
        Tateti tateti = new Tateti();
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

    public void SetPositionInMatrix(int x, int y, int position)
    {
        //given
        Tateti tateti = new Tateti();
        int[] positionInMatrix = { x, y };

        //when

        //Then
        Assert.AreEqual(positionInMatrix, tateti.SetPositionInMatrix(position));
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

    public void SaveCrossInMatrix(string player, int x, int y, int position)
    {
        //given
        Tateti tateti = new Tateti();

        //when
        tateti.SaveCrossInMatrix(player, tateti.SetPositionInMatrix(position));

        //Then
        Assert.IsTrue(tateti.Matrix[x,y].Contains(player));
    }

    [TestCase("Player1", 0)]
    [TestCase("Player2", 1)]
    [TestCase(null, 2)]

    public void CheckIfIsTateti(string[,] matrix, string player)
    {
        //given
        Tateti tateti = new Tateti();

        //Then
        Assert.IsTrue(tateti.CheckIfIsTateti(matrix,player));
    }
}
