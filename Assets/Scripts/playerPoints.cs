using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerPoints : MonoBehaviour
{
    public int playerPointsNum;
    public GameObject pointsText;
    // Start is called before the first frame update
    void Start()
    {
        playerPointsNum = 0;
        pointsText.GetComponent<TextMeshProUGUI>().text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        playerPointsNum += 1;
        pointsText.GetComponent<TextMeshProUGUI>().text = playerPointsNum.ToString();
    }
}
