using UnityEngine;
using System.Collections;

public class Coordinates : MonoBehaviour// this class is for the cordinates of the grid 
    // the grid 1234..81
{
    public int postion { get; set; }
    public Coordinates(int number)
    {
        postion = number;
    }
}
