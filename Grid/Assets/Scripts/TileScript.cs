using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TileScript : MonoBehaviour{
    public Point GridPos { get; private set; }
    public bool wait = false;

    public void setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        this.GridPos = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        GridManager.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver(){
        //Debug.Log(transform.position.x + ", " + transform.position.y);

        // && GameManager.Instance.ClickedShip != null
        if (TurnManager.Instance.AIturn1)
        {
            GameManager.Instance.ShotsShowAI(true);
            GameManager.Instance.ShotsShowPlayer(false);
            LoadShips(true);
            AIPlace();
        }
        else
        {
            if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.HitPrefab != null && GameManager.Instance.MissPrefab != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameManager.Instance.ShotsShowAI(false);
                    GameManager.Instance.ShotsShowPlayer(true);
                    HitOrMiss();
                    //placeShip();
                    LoadShips(false);
                    GameManager.Instance.missiles--;
                }
                if (GameManager.Instance.missiles <= 0)
                {
                    TurnManager.Instance.AIturn1 = true;
                }
            }
        }
    }

    private void AIPlace()
    {
        if (GameManager.Instance.HitPrefab != null && GameManager.Instance.MissPrefab != null)
        {
            int i = 0;
            while(i < 5)
            {
                Point tile = AITurn.Instance.PickTile();
                GameObject obj;
                if (GameManager.Instance.CheckHit(tile.X, tile.Y))
                {
                    obj = Instantiate(GameManager.Instance.HitPrefab, new Vector3(tile.X, tile.Y), Quaternion.identity);
                }
                else
                {
                    obj = Instantiate(GameManager.Instance.MissPrefab, new Vector3(tile.X, tile.Y), Quaternion.identity);
                }
                //obj.transform.SetParent(GridManager.Instance.Tiles[tile].transform);
                obj.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 20;
                GameManager.Instance.AIshots.Add(obj);
                i++;
            }
            GameManager.Instance.missiles = 5;
            TurnManager.Instance.AIturn1 = false;
        }
    }

    private void LoadShips(bool val)
    {
        GameManager.Instance.TwoSpace.SetActive(val);
        GameManager.Instance.ThreeSpace1.SetActive(val);
        GameManager.Instance.ThreeSpace2.SetActive(val);
        GameManager.Instance.FourSpace.SetActive(val);
        GameManager.Instance.FiveSpace.SetActive(val);
    }

    private void HitOrMiss(){
        GameObject obj;
        if (GameManager.Instance.CheckHit((int)transform.position.x, (int)transform.position.y))
        {
            //Debug.Log("HIT");
            obj = Instantiate(GameManager.Instance.HitPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            //Debug.Log("MISS");
            obj = Instantiate(GameManager.Instance.MissPrefab, transform.position, Quaternion.identity);
        }
        GameManager.Instance.Playershots.Add(obj);
        //obj.transform.SetParent(transform);
        obj.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 20;
    }

    //Used the place the ship on the grid
    private void placeShip(){
        GameObject ship = Instantiate(GameManager.Instance.ClickedShip.ShipPrefab, transform.position, Quaternion.identity);
        ship.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 1;
        ship.transform.SetParent(transform);
        GameManager.Instance.shipPlaced();
    }
}
