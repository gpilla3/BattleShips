﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : Singleton<TurnManager>
{
    private bool AIturn = false;

    public bool AIturn1 { get => AIturn; set => AIturn = value; }
}