using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ButtonView : MonoBehaviour
{
    [SerializeField] internal Button selectedPosition;
    [SerializeField] private Image crossImage;
    [SerializeField] private Image circleImage;

    public void Init()
    {
        crossImage.gameObject.SetActive(false);
        circleImage.gameObject.SetActive(false);
    }

    internal void SetImageToButton(string player)
    {
    if (player == "Player1")
    {
        crossImage.gameObject.SetActive(true);
    }
    else
    {
        circleImage.gameObject.SetActive(true);
    }
}
}
