using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public List<Point> points = new List<Point>();
    public List<GameObject> AIshots = new List<GameObject>();
    public List<GameObject> Playershots = new List<GameObject>();

    private int shipsNotDestroyed = 5;
    public int missiles = 5;

    public TMPro.TextMeshProUGUI missileText;

    public ShipBtn ClickedShip { get; private set; }

    private void Start()
    {
        missileText.SetText("Missiles: " + missiles.ToString());
    }

    private void Update()
    {
        missileText.SetText("Missiles: " + missiles.ToString());
    }

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

    public void StorePoints()
    {
        points.Add(new Point(-3, 3));
        points.Add(new Point(-2, 3));
        points.Add(new Point(-1, 3));
        points.Add(new Point(0, 3));
        points.Add(new Point(1, 3));

        points.Add(new Point(-4, 1));
        points.Add(new Point(-3, 1));
        points.Add(new Point(-2, 1));

        points.Add(new Point(1, 1));
        points.Add(new Point(2, 1));
        points.Add(new Point(3, 1));

        points.Add(new Point(-3, -1));
        points.Add(new Point(-2, -1));

        points.Add(new Point(0, -3));
        points.Add(new Point(1, -3));
        points.Add(new Point(2, -3));
        points.Add(new Point(3, -3));
    }

    public void ShotsShowAI(bool val)
    {
        Debug.Log("Hiding AI Shots");
        foreach(GameObject g in AIshots)
        {
            g.SetActive(val);
        }
    }

    public void ShotsShowPlayer(bool val)
    {
        Debug.Log("Hiding Player Shots");
        foreach (GameObject g in Playershots)
        {
            g.SetActive(val);
        }
    }
}
