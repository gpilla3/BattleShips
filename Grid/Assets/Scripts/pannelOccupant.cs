using UnityEngine;
using System.ComponentModel;

public class pannelOccupant : MonoBehaviour
{
    public pannelOccupant Submarine { get; internal set; }
    public pannelOccupant Battleship { get; internal set; }
    public pannelOccupant Carrier { get; internal set; }
    public pannelOccupant PatrolBoat { get; internal set; }
    public pannelOccupant Destroyer { get; internal set; }

    // Use this for initialization
    public enum PannelOccupant
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
