using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private RaycastHit raycastHit;
    private Ray ray;

    [SerializeField]
    private GameObject hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
    }

    void TakeInput()
    {
        if (Input.touches.Length > 0 && Input.touches[0].phase == TouchPhase.Ended)
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        else if (Input.GetMouseButtonUp(0))
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        else
        {
            return;
        }

        if (Physics.Raycast(ray, out raycastHit))
        {
            GameObject tile = raycastHit.transform.gameObject;
            switch (tile.tag)
            {
             //we are only allowed to touch on game tiles!
             case "waterTile":
                    Debug.Log("waterTile");
                    GameObject h = Instantiate(hit, transform);
                    h.transform.position = tile.transform.position;
                    break;
            }
        }
    }
}
