using System.Collections.Generic;
using UnityEngine;

//Used to manage the Grid the players play on
public class GridManager : Singleton<GridManager>{
    [SerializeField]
    private int rows = 9;
    [SerializeField]
    private int cols = 9;
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private Transform Playermap;
    [SerializeField]
    private Transform AImap;
    private float tileSize = 1;

    public Dictionary<Point, TileScript> Tiles { get; set; }

    // Start is called before the first frame update
    void Start(){
        GenerateGrid(); //Creates the grid the players will play on
    }

    //Function used to generate the grid
    private void GenerateGrid(){
        Tiles = new Dictionary<Point, TileScript>();

        //Created a 9 x 9 Grid
        for (int y = 0; y < rows; y++){
            for (int x = 0; x < cols; x++){
                PlaceTile(y, x);
            }
        }

        float width = cols * tileSize;
        float height = rows * tileSize;
        Playermap.position = new Vector3(-width / 2 + tileSize / 2, height / 2 - tileSize / 2);
        GameManager.Instance.StorePoints(); //Stores the points
    }

    //Function used to place the tiles
    private void PlaceTile(int y, int x){
        TileScript newtile = Instantiate(tile, transform).GetComponent<TileScript>();
        float posX = x * tileSize;
        float posY = y * -tileSize;

        newtile.setup(new Point(x, y), new Vector3(posX, posY), Playermap);
    }
}
