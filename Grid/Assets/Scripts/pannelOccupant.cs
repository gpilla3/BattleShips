using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class pannelOccupant : MonoBehaviour// enum values for the pannel occupation 
{
    public pannelOccupant Submarine { get; internal set; }
    public pannelOccupant Battleship { get; internal set; }
    public pannelOccupant Destroyer { get; internal set; }
    public pannelOccupant PatrolBoat { get; internal set; }
    public pannelOccupant Carrier { get; internal set; }

    public enum PannelOccupant//this has the ships and if the pannel has been attacked or hasent been attacked
        // description is the value of the said enum
    {
        [Description("O")]
        Empty,

        [Description("B")]
        Battleship,

        [Description("P")]
        PatrolBoat,

        [Description("D")]
        Destroyer,

        [Description("S")]
        Submarine,

        [Description("C")]
        Carrier,

        [Description("X")]
        Hit,

        [Description("M")]
        Miss,

        [Description("T")]
        Targeted,
    }
}
