using UnityEngine;
using System.Collections;
using static pannelOccupant;

public class gridPannel : MonoBehaviour
{

    // Use this for initialization
    public PannelOccupant PannelOccupant { get; set; }
    public Coordinates Coordinates { get; set; }

    public gridPannel(int postion){
        Coordinates = new Coordinates(postion);
        PannelOccupant = PannelOccupant.Empty;
    }


    public bool PannelFree
    {
        get
        {
            return PannelOccupant == PannelOccupant.Battleship
            || PannelOccupant == PannelOccupant.Carrier
            || PannelOccupant == PannelOccupant.Cruiser
            || PannelOccupant == PannelOccupant.Destroyer
            || PannelOccupant == PannelOccupant.Submarine;
        }
    }


}
