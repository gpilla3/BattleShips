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

    public ShipBtn ClickedShip { get; private set; }

    public GameObject HitPrefab {
        get
        {
            return hitPrefab;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
