using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class pannelOccupant : MonoBehaviour
{
    public pannelOccupant Submarine { get; internal set; }
    public pannelOccupant Battleship { get; internal set; }

    // Use this for initialization
    public enum PannelOccupant
    {
        [Description("o")]
        Empty,

        [Description("B")]
        Battleship,

        [Description("C")]
        Cruiser,

        [Description("D")]
        Destroyer,

        [Description("S")]
        Submarine,

        [Description("A")]
        Carrier,

        [Description("X")]
        Hit,

        [Description("M")]
        Miss,

        [Description("T")]
        Targeted,
    }
}
