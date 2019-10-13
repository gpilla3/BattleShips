using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TileScript : MonoBehaviour{
    public Point GridPos { get; private set; }
    public List<Point> points = new List<Point>();

    public void setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        this.GridPos = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        GridManager.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver(){
        //Debug.Log(transform.position.x + ", " + transform.position.y);
        if (!TurnManager.Instance.AIturn1)
        {
            if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.HitPrefab != null && GameManager.Instance.MissPrefab != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("HitOrMiss");
                    HitOrMiss();
                    LoadShips(true);
                    //SceneManager.LoadScene(1);
                    TurnManager.Instance.AIturn1 = false;
                }
            }
        }
        else
        {
            if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedShip != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Placing Ship");
                    //placeShip();
                    TurnManager.Instance.AIturn1 = true;
                    LoadShips(false);
                    //SceneManager.LoadScene(2);
                }
            }
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
        if (CheckHit((int)transform.position.x, (int)transform.position.y))
        {
            Debug.Log("HIT");
            obj = Instantiate(GameManager.Instance.HitPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("MISS");
            obj = Instantiate(GameManager.Instance.MissPrefab, transform.position, Quaternion.identity);
        }
        obj.transform.SetParent(transform);
        obj.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 20;
    }

    private void StorePoints()
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

    private bool CheckHit(int x, int y)
    {
        points.Clear();
        StorePoints();
        Debug.Log("Capacity: " + points.Capacity);
        foreach(Point p in points)
        {
            if (p.X == x && p.Y == y)
                return true;
        }
        return false;
    }

    private void placeShip(){
        GameObject ship = Instantiate(GameManager.Instance.ClickedShip.ShipPrefab, transform.position, Quaternion.identity);
        ship.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 1;
        ship.transform.SetParent(transform);
        GameManager.Instance.shipPlaced();
    }
}
