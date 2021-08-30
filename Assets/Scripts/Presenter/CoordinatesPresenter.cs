using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatesPresenter 
{
    private Coordinates coordinates = new Coordinates();
    public void Initialize(ITatetiView tatetiView)
    {
        coordinates.CleanMatrix();
    }
    public void RestartGame()
    {
        coordinates.CleanMatrix();
    }

}
