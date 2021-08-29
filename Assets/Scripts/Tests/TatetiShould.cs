using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TatetiShould
{
    // Debe haber una matriz de 3x3
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

    // La matriz debe crearse vacía
    [Test]
    public void HasAnEmptyMatrix()
    {
        //given
        Tateti tateti = new Tateti();

        //Then
        Assert.IsNotNull(tateti.Matrix);
    }
}
