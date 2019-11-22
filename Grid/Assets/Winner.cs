using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI winnerText;

    // Update is called once per frame
    void Update()
    {
        if(winnerText != null)
        {
            winnerText.SetText("Your overall Questions Answered has increased to " + DBManager.userScore);
        }
    }
}
