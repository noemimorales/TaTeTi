using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TatetiView : MonoBehaviour
{
    [SerializeField] private Button[] inputButton;
    [SerializeField] private Button playAgainButton;

    private int size = 3;

    private Sprite crossImage;
    private Sprite cicleImage;

 
    // Start is called before the first frame update
    void Start()
    {
        SetInputAtions();
    }

    private void SetInputAtions()
    {
        for(int i = 0; i < inputButton.Length; i++)
        {
            int positionInArray = 1;
            inputButton[positionInArray].onClick.AddListener(()=> {
                int x = GetXPosition(positionInArray);
                int y = GETYPosition(positionInArray);
                OnClickInput(x, y);
            });
        }
    }

    private void OnClickInput(int x, int y)
    {
        
    }

    private int GETYPosition(int positionInArray)
    {
        return positionInArray / size;
    }

    private int GetXPosition(int positionInArray)
    {
        return positionInArray % size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
