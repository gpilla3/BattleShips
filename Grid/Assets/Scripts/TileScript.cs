using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour{
    public Point GridPos { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        this.GridPos = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        GridManager.Instance.Tiles.Add(gridPos, this);
    }
}
