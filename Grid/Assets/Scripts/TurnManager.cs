using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : Singleton<TurnManager>
{
    private bool AIturn;

    public bool AIturn1
    {
        get
        {
            return AIturn;
        }
        set
        {
            AIturn = value;
            Debug.Log("Setting Value: " + value);
        }
    }
}
