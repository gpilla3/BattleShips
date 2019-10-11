using UnityEngine;
using System.Collections;

public abstract class Ships : MonoBehaviour
{

    public string Name { get; set; }
    public int Width { get; set; }
    public int Hits { get; set; }
    public pannelOccupant pannelOccupant { get; set; }
    public bool IsSunk
    {
        get
        {
            return Hits >= Width;
        }
    }
}

