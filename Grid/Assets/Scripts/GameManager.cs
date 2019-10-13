using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject hitPrefab;
    [SerializeField]
    private GameObject missPrefab;
    [SerializeField]
    private GameObject twoSpace;
    [SerializeField]
    private GameObject threeSpace1;
    [SerializeField]
    private GameObject threeSpace2;
    [SerializeField]
    private GameObject fourSpace;
    [SerializeField]
    private GameObject fiveSpace;

    private int shipsNotDestroyed = 5;
    private int missiles = 5;

    public ShipBtn ClickedShip { get; private set; }

    public GameObject HitPrefab {
        get
        {
            return hitPrefab;
        }
    }

    public GameObject MissPrefab
    {
        get
        {
            return missPrefab;
        }
    }

    public GameObject TwoSpace
    {
        get
        {
            return twoSpace;
        }
    }

    public GameObject ThreeSpace1
    {
        get
        {
            return threeSpace1;
        }
    }

    public GameObject ThreeSpace2
    {
        get
        {
            return threeSpace2;
        }
    }

    public GameObject FourSpace
    {
        get
        {
            return fourSpace;
        }
    }

    public GameObject FiveSpace
    {
        get
        {
            return fiveSpace;
        }
    }

    public void SelectShip(ShipBtn shipbtn)
    {
        this.ClickedShip = shipbtn;
        //Hover.Instance.Activate(ClickedShip.Sprite);
    }

    public void shipPlaced()
    {
        ClickedShip = null;
    }
}
