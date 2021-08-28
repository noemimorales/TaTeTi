using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TatetiView : MonoBehaviour
{
    [SerializeField] private Button[] inputButtons;
    [SerializeField] private Button playAgainButton;

    private int size = 3;

    [SerializeField] private Sprite crossImage;
    [SerializeField] private Sprite cicleImage;

 
    // Start is called before the first frame update
    void Start()
    {
        SetInputAtions();
    }

    private void SetInputAtions()
    {
        for(int positionInArray = 0; positionInArray < inputButtons.Length; positionInArray++)
        {
            inputButtons[positionInArray].onClick.AddListener(()=> {
                int x = GetXPosition(positionInArray);
                int y = GETYPosition(positionInArray);
                OnClickInput(x, y);
            });
         }
    }

    private void OnClickInput(int x, int y)
    {
        SetCross(x,y);
    }

    private int GETYPosition(int positionInArray)
    {
        return positionInArray / size;
    }

    private int GetXPosition(int positionInArray)
    {
        return positionInArray % size;
    }
    private void SetCircle(int x,int y)
    {
        inputButtons[GetIndexFromCoordinates(x, y)].image.sprite = cicleImage;
    }

    private void SetCross(int x, int y)
    {
        inputButtons[GetIndexFromCoordinates(x, y)].image.sprite = crossImage;
    }
    private int GetIndexFromCoordinates(int x, int y)
    {
        return x + y * size;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
