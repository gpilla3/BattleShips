using UnityEngine;
using UnityEditor;
using static pannelOccupant;

public class Battleship : Ships
{
    public Battleship()
    {
        Name = "Battleship";
        Width = 4;
        pannelOccupant = pannelOccupant.Battleship;
    }
}