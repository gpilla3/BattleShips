using UnityEngine;
using System.Collections;
using static pannelOccupant;

public class gridPannel : MonoBehaviour
{/*
    each grid pannel will need a type so we can tell if it has been attack and if thier is something on it
    also we will need to know the coordinate of the pannel
   */
    public PannelOccupant PannelOccupant { get; set; }// what is on the pannel
    public Coordinates Coordinates { get; set; }// where the pannel is located

    public gridPannel(int postion){// set the postion of the pannel and type of pannel
        Coordinates = new Coordinates(postion);
        PannelOccupant = PannelOccupant.Empty;
    }


    public bool PannelFree// if thier is nothing on the pannel ie a ship
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
