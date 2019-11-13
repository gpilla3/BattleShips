using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject hitPrefab = null;
    [SerializeField]
    private GameObject missPrefab = null;
    [SerializeField]
    private GameObject wrongPrefab = null;
    [SerializeField]
    private GameObject twoSpace = null;
    [SerializeField]
    private GameObject threeSpace1 = null;
    [SerializeField]
    private GameObject threeSpace2 = null;
    [SerializeField]
    private GameObject fourSpace = null;
    [SerializeField]
    private GameObject fiveSpace = null;
    [SerializeField] public GameObject continueButton = null;
    public Vector3 lastPos = new Vector3();
    public Quaternion lastQuaternion;
    public GameObject obj = null;
    public int GridPosY;

    public bool answeredCorrectly = false;
    public int correctAnswer = 0;

    [SerializeField] public GameObject theGridStuff = null;
    [SerializeField] public GameObject theQuestionHolder = null;

    public List<Point> points = new List<Point>();
    public List<GameObject> AIshots = new List<GameObject>();
    public List<GameObject> Playershots = new List<GameObject>();

    //private int shipsNotDestroyed = 5;
    public int missiles = 5;
    public int totalHits = 17;
    public int totlHitsAI = 17;

    public TMPro.TextMeshProUGUI missileText;

    private void Start()
    {
        if (missileText != null)
        {
            missileText.SetText("Missiles: " + missiles.ToString());
        }
    }

    private void Update()
    {
        if(missileText != null)
        {
            missileText.SetText("Missiles: " + missiles.ToString());
        }
    }

    public GameObject HitPrefab
    {
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

    public GameObject WrongPrefab
    {
        get
        {
            return wrongPrefab;
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
        //Debug.Log("Hiding AI Shots");
        foreach (GameObject g in AIshots)
        {
            g.SetActive(val);
        }
    }

    public void ShotsShowPlayer(bool val)
    {
        //Debug.Log("Hiding Player Shots");
        foreach (GameObject g in Playershots)
        {
            g.SetActive(val);
        }
    }

    public bool CheckHit(int x, int y)
    {
        foreach (Point p in points)
        {
            if (p.X == x && p.Y == y)
                return true;
        }
        return false;
    }

    public void hideStuff()
    {
        theGridStuff.SetActive(false);
        theQuestionHolder.SetActive(true);
    }

    public void LoadShips(bool val)
    {
        TwoSpace.SetActive(val);
        ThreeSpace1.SetActive(val);
        ThreeSpace2.SetActive(val);
        FourSpace.SetActive(val);
        FiveSpace.SetActive(val);
    }

    public void continueClicked()
    {
        LoadShips(false);
        continueButton.SetActive(false);
        ShotsShowAI(false);
        ShotsShowPlayer(true);
        missiles = 5;
    }
}
