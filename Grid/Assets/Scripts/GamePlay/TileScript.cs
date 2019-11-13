using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TileScript : MonoBehaviour
{
    public Point GridPos { get; private set; }
    public bool wait = false;

    public void setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        this.GridPos = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        GridManager.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver()
    {
        //Debug.Log(transform.position.x + ", " + transform.position.y);
        if (TurnManager.Instance.AIturn1)
        {
            GameManager.Instance.ShotsShowAI(true);
            GameManager.Instance.ShotsShowPlayer(false);
            GameManager.Instance.LoadShips(true);
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
                    GameManager.Instance.missiles--;
                }
                if (GameManager.Instance.missiles == 0)
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
            while (i < 5)
            {
                Point tile = AITurn.Instance.PickTile();
                GameObject obj;
                if (GameManager.Instance.CheckHit(tile.X, tile.Y))
                {
                    var chance = Random.Range(0, 3);
                    if (chance == 1)
                    {
                        obj = Instantiate(GameManager.Instance.HitPrefab, new Vector3(tile.X, tile.Y), Quaternion.identity);
                    }
                    else
                    {
                        obj = Instantiate(GameManager.Instance.WrongPrefab, new Vector3(tile.X, tile.Y), Quaternion.identity);
                    }
                    GameManager.Instance.totlHitsAI--;
                }
                else
                {
                    obj = Instantiate(GameManager.Instance.MissPrefab, new Vector3(tile.X, tile.Y), Quaternion.identity);
                    GameManager.Instance.totlHitsAI--;
                }
                if (GameManager.Instance.totlHitsAI == 0)
                {
                    SceneManager.LoadScene(8);
                    return;
                }
                //obj.transform.SetParent(GridManager.Instance.Tiles[tile].transform);
                obj.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 20;
                GameManager.Instance.AIshots.Add(obj);
                i++;
            }
            GameManager.Instance.missiles = 5;
            TurnManager.Instance.AIturn1 = false;
            GameManager.Instance.continueButton.SetActive(true);
        }
    }

    private void HitOrMiss()
    {
        GameObject obj;
        if (GameManager.Instance.CheckHit((int)transform.position.x, (int)transform.position.y))
        {
            //Debug.Log("HIT");
            GameManager.Instance.hideStuff();
            GameManager.Instance.lastPos = transform.position;
            GameManager.Instance.lastQuaternion = Quaternion.identity;
            obj = Instantiate(GameManager.Instance.WrongPrefab, transform.position, Quaternion.identity);
            GameManager.Instance.obj = obj;
        }
        else
        {
            //Debug.Log("MISS");
            obj = Instantiate(GameManager.Instance.MissPrefab, transform.position, Quaternion.identity);
        }
        GameManager.Instance.Playershots.Add(obj);
        GameManager.Instance.GridPosY = GridPos.Y;
        //obj.transform.SetParent(transform);
        obj.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 20;
        GameManager.Instance.totalHits--;
        if (GameManager.Instance.totalHits == 0)
        {
            SceneManager.LoadScene(7);
            return;
        }
    }
}
