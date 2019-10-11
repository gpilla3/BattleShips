using UnityEngine;
using System.Collections;

public class Destroyer : Ships
{

    public Destroyer()
    {
        Name = "Destroyer";
        Width = 3;
        pannelOccupant = pannelOccupant.Destroyer;
    }
}
