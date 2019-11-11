using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject shipPrefab;

    [SerializeField]
    private Sprite sprite;

    public GameObject ShipPrefab
    {
        get
        {
            return shipPrefab;
        }
    }

    public Sprite Sprite {
        get{
            return sprite;
        }
    }
}
