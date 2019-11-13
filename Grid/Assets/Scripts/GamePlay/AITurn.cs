﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AITurn : Singleton<AITurn>
{
    public System.Random Randval = new System.Random();
    private List<Point> selectedPoints = new List<Point>();
    private Point thePoint;
    private int x, y;

    private bool isPresent(int x, int y)
    {
        foreach (var p in selectedPoints)
        {
            if (p.X == x && p.Y == y)
            {
                return true;
            }
        }
        return false;
    }

    public Point PickTile()
    {
        x = Randval.Next(-4, 4);
        y = Randval.Next(-4, 4);
        while (isPresent(x, y))
        {
            x = Randval.Next(-4, 4);
            y = Randval.Next(-4, 4);
        }
        //dude try and use this function? sure
        Debug.Log("Selected Point: (" + x + ", " + y + ")");
        thePoint = new Point(x, y);
        selectedPoints.Add(thePoint);
        return thePoint;
    }
}