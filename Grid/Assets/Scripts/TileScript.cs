using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    private void OnMouseOver(){
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedShip != null && GameManager.Instance.HitPrefab != null){
            if (Input.GetMouseButtonDown(0)){
                placeShip();
            }
        }
    }

    private void HitOrMiss(){
        GameObject hit = Instantiate(GameManager.Instance.HitPrefab, transform.position, Quaternion.identity);
        hit.transform.SetParent(transform);
    }

    private void placeShip(){
        GameObject ship = Instantiate(GameManager.Instance.ClickedShip.ShipPrefab, transform.position, Quaternion.identity);
        ship.GetComponent<SpriteRenderer>().sortingOrder = GridPos.Y + 1;
        ship.transform.SetParent(transform);
        GameManager.Instance.shipPlaced();
    }
}
