using UnityEngine;
using System.Collections;
using static pannelOccupant;

public class Submarine : Ships
{

    public Submarine()
    {
        Name = "Submarine";
        Width = 3;
        pannelOccupant = pannelOccupant.Submarine;
    }

}
