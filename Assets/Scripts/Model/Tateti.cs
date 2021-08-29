using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tateti 
{
    private string[,] matrix = new string[3, 3];
    public string[,] Matrix { get => matrix; set => matrix = value; }
    public Tateti()
    {
    }
}
