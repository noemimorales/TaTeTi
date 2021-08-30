using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatesPresenter 
{
    private Coordinates coordinates = new Coordinates();
    private ITatetiView tatetiView;

    public void InitializeCoordinates(ITatetiView tatetiView)
    {
        this.tatetiView = tatetiView;
        tatetiView.InitializeCoordinates(this);
        coordinates.CleanMatrix();
    }
    public void RestartGame()
    {
        coordinates.CleanMatrix();
    }

}
