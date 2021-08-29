using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ITatetiView
{
    void Initialize(TatetiPresenter tatetiPresenter);
    void SetWinner(string winner);

}