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
    
    //[TestCase("Player1",true)]
    //[TestCase("Player2", false)]
    //public void SavePlayer(string expectedPlayer, bool isPlayer1)
    //{
    //    //Then
    //    Assert.AreEqual(expectedPlayer, tateti.DetectPlayer(isPlayer1));
    //}

    [TestCase(false, true)]
    [TestCase(true, false)]
    public void ChangePlayerAfterPlay(bool expectedPlayer, bool isPlayer1)
    {
        //given
        tateti.ChangePlayer(isPlayer1);
        //Then
        Assert.AreEqual(expectedPlayer,tateti.IsFirstPlayer);
    }

    [Test]
    public void CheckIfIsTateti()
    {
        //given
        Coordinates coordinates = new Coordinates();
        string player;
        player = "Player1";

        //when
        coordinates.Matrix[0, 0] = player;
        coordinates.Matrix[1, 0] = player;
        coordinates.Matrix[2, 0] = player;

        //Then
        Assert.IsTrue(tateti.CheckIfIsTateti(coordinates.Matrix,player));
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

}
