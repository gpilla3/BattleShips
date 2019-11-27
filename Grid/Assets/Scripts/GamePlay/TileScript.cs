using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//Used to control what happens for each individual tile
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

    //If the tile has mouse over it
    private void OnMouseOver()
    {
        //Checks whose turn it is
        if (TurnManager.Instance.AIturn1)
        {
            //AI's turn
            GameManager.Instance.ShotsShowAI(true);
            GameManager.Instance.ShotsShowPlayer(false);
            GameManager.Instance.LoadShips(true);
            AIPlace();
        }
        else
        {
            //Player's turn
            if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.HitPrefab != null && GameManager.Instance.MissPrefab != null)
            {
                //If the player pressed down on a tile
                if (Input.GetMouseButtonDown(0))
                {
                    GameManager.Instance.ShotsShowAI(false);
                    GameManager.Instance.ShotsShowPlayer(true);
                    HitOrMiss(); //Calls HitOrMiss()
                    GameManager.Instance.missiles--;
                }
                //Changes to the AI turn if all missiles have been used up
                if (GameManager.Instance.missiles == 0)
                {
                    TurnManager.Instance.AIturn1 = true;
                }
            }
        }
    }

    //Used to place the missile based on which point in the Grid the AI selected
    private void AIPlace()
    {
        if (GameManager.Instance.HitPrefab != null && GameManager.Instance.MissPrefab != null)
        {
            int i = 0;
            //Selects 5 unique points in the grid
            while (i < 5)
            {
                Point tile = AITurn.Instance.PickTile(); //Picks a tile
                GameObject obj;
                //Checks if it's a hit
                if (GameManager.Instance.CheckHit(tile.X, tile.Y))
                {
                    //it's a hit
                    var chance = Random.Range(0, 3); //Decides if the AI gets the question right or wrong
                    //Places a Correct marker
                    if (chance == 1)
                    {
                        obj = Instantiate(GameManager.Instance.HitPrefab, new Vector3(tile.X, tile.Y), Quaternion.identity);
                    }
                    //Places a Wrong Marker
                    else
                    {
                        obj = Instantiate(GameManager.Instance.WrongPrefab, new Vector3(tile.X, tile.Y), Quaternion.identity);
                    }
                    GameManager.Instance.totlHitsAI--;
                }
                //It's a miss so places a miss marker
                else
                {
                    obj = Instantiate(GameManager.Instance.MissPrefab, new Vector3(tile.X, tile.Y), Quaternion.identity);
                }
                //The AI won
                if (GameManager.Instance.totlHitsAI == 0)
                {
                    SceneManager.LoadScene(7);
                    return;
                }
                obj.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 20;
                GameManager.Instance.AIshots.Add(obj);
                i++;
            }
            //Setting the turn to be the players turn
            GameManager.Instance.missiles = 5;
            TurnManager.Instance.AIturn1 = false;
            GameManager.Instance.continueButton.SetActive(true);
            GameManager.Instance.turn.SetText("Showing Opponents Turn. Click Attack to Continue");
        }
    }

    //Checks if the tile that was clicked is a hit or a miss
    //Checking if there is a ship there or not, Used for the player
    private void HitOrMiss()
    {
        GameObject obj;
        //If it's a hit place a hit marker
        if (GameManager.Instance.CheckHit((int)transform.position.x, (int)transform.position.y))
        {
            GameManager.Instance.hideStuff();
            GameManager.Instance.lastPos = transform.position;
            GameManager.Instance.lastQuaternion = Quaternion.identity;
            obj = Instantiate(GameManager.Instance.WrongPrefab, transform.position, Quaternion.identity);
            GameManager.Instance.obj = obj;
            GameManager.Instance.totalHits--;
        }
        //place a miss marker
        else
        {
            obj = Instantiate(GameManager.Instance.MissPrefab, transform.position, Quaternion.identity);
        }
        //Adding the shot that was made to a list
        GameManager.Instance.Playershots.Add(obj);
        GameManager.Instance.GridPosY = GridPos.Y;
        obj.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 20;

        //The player won
        if (GameManager.Instance.totalHits == 0)
        {
            SceneManager.LoadScene(6);
            return;
        }
    }
}
