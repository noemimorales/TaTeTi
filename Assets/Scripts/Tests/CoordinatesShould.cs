using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CoordinatesShould
{
    Coordinates coordinates;
    [SetUp]
    public void Before()
    {
        coordinates = new Coordinates();
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
        Assert.AreEqual(positionInMatrix, coordinates.ObtainPositionInMatrix(position));
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
        coordinates.SavePositionInMatrix(player, coordinates.ObtainPositionInMatrix(position));

        //Then
        Assert.IsTrue(coordinates.Matrix[x, y].Contains(player));
    }

    [Test]
    public void HasAThreeByThreeMatrix()
    {
        //when
        string[,] expectedMatrix = new string[3, 3];
        string[,] resultMatrix = coordinates.Matrix;

        //then
        Assert.AreEqual(expectedMatrix.GetLength(0), resultMatrix.GetLength(0));
        Assert.AreEqual(expectedMatrix.GetLength(1), resultMatrix.GetLength(1));
        
    }

    [Test]
    public void GetPlayerPositions()
    {
        //given
        string player;
        string expectedPositions;

        //when
        player = "Player1";
        coordinates.Matrix[0, 0] = player;
        coordinates.Matrix[1, 0] = player;
        coordinates.Matrix[2, 0] = player;
        expectedPositions = "012";

        //Then
        Assert.AreEqual(expectedPositions, coordinates.GetPlayerPositions(coordinates.Matrix, player));
    }
}
