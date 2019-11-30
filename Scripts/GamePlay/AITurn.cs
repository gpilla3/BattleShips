using System.Collections.Generic;
using UnityEngine;

//Used to control the AI's turb
public class AITurn : Singleton<AITurn>
{
    public System.Random Randval = new System.Random();
    private List<Point> selectedPoints = new List<Point>();
    private Point thePoint;
    private int x, y;

    //Used to verify if the point that was selected is already selected before
    private bool isPresent(int x, int y)
    {
        foreach (var p in selectedPoints)
        {
            if (p.X == x && p.Y == y)
            {
                return true; //already selected
            }
        }
        return false; //unique point on the grid
    }

    //Selecting points on the grid to attack
    public Point PickTile()
    {
        x = Randval.Next(-4, 4);
        y = Randval.Next(-4, 4);
        while (isPresent(x, y))
        {
            x = Randval.Next(-4, 4);
            y = Randval.Next(-4, 4);
        }
        Debug.Log("Selected Point: (" + x + ", " + y + ")");
        thePoint = new Point(x, y);
        selectedPoints.Add(thePoint); //Adding the points to the selected points list
        return thePoint;
    }
}
