using UnityEngine;
using System.Collections;

public abstract class Ships : MonoBehaviour
{/* this class is the sbstract class for the 5 ships we will have in the game so all
    we have to add do is create 5 different classes for the ships 1 per ship which will use this framework
    name of ship how many hits the ship can take and how many hits the ship has
    */
    public string Name { get; set; }
    public int Width { get; set; }
    public int Hits { get; set; }
    public pannelOccupant pannelOccupant { get; set; }// sets the type of pannel occupant so when put on a grid pannel the grid knows what ship it is
    public bool IsSunk// if the hits on the ship equeal to width of the ship then the ship is sunk
    {
        get
        {
            return Hits >= Width;
        }
    }
}

