using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPoints : MonoBehaviour
{
    public int playerPointsNum;
    // Start is called before the first frame update
    void Start()
    {
        playerPointsNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        playerPointsNum += 1;
    }
}
