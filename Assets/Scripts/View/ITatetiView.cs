using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ITatetiView
{
    void InitializeTateti(TatetiPresenter tatetiPresenter);
    void InitializeCoordinates(CoordinatesPresenter coordinatesPresenter);
    void SetWinner(string winner);
    void InstantiateButtons(List<string> buttons);
}