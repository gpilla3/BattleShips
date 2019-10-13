using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AITurn : Singleton<AITurn>
{
    public System.Random Randval = new System.Random();
    private List<Point> selectedPoints = new List<Point>();

    public Point PickTile()
    {
        int x = Randval.Next(-4, 4);
        int y = Randval.Next(-4, 4);
        Debug.Log("Random Point: " + x + ", " + y);
        foreach(Point p in selectedPoints){
            if (p.X == x && p.Y == y)
                PickTile();
        }
        Point thePoint = new Point(x, y);
        selectedPoints.Add(thePoint);
        return thePoint;
    }
}
