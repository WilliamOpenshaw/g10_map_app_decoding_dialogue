using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;

//using System.Numerics;
using UnityEngine;
//using UnityEngine.Vector2;

public class Tetris : MonoBehaviour
{
    public GameObject square0;
    public GameObject long0;
    public GameObject zigzag0;
    public GameObject square1;
    public GameObject long1;
    public GameObject zigzag1;
    public GameObject square2;
    public GameObject long2;
    public GameObject zigzag2;
    public GameObject square3;
    public GameObject long3;
    public GameObject zigzag3;
    public GameObject square4;
    public GameObject long4;
    public GameObject zigzag4;

    public GameObject square0Sentence;
    public GameObject long0Sentence;
    public GameObject zigzag0Sentence;
    public GameObject zigzag0Sentence2;
    public GameObject square1Sentence;
    public GameObject long1Sentence;
    public GameObject zigzag1Sentence;
    public GameObject zigzag1Sentence2;
    public GameObject square2Sentence;
    public GameObject long2Sentence;
    public GameObject zigzag2Sentence;
    public GameObject zigzag2Sentence2;
    public GameObject square3Sentence;
    public GameObject long3Sentence;
    public GameObject zigzag3Sentence;
    public GameObject zigzag3Sentence2;
    public GameObject square4Sentence;
    public GameObject long4Sentence;
    public GameObject zigzag4Sentence;
    public GameObject zigzag4Sentence2;

    //saved start position for shapes
    public Vector2 startPos; 
    //saved number for random piece choosing
    public int choiceNumber = 0;

    //saved time for checking how much time has gone by
    public float lastTime;

    //saved yes/no true/false for when to keep making more pieces
    public bool keepSpawning;

    //to count how many times a random choice has been tried
    public int tryNumber;

    //list of shapes so we can call them by number instead of by name
    public GameObject[] shapes;

    //to save the position controller for shapes
    //so our code lines are shorter and easier to read
    public RectTransform rect;

    public float xPositionCheck;
    
    // Everything in Start() happens one time at the beginning
    void Start()
    {
        // These set our shapes into a numbered list that we can easily use
        // to randomly call different shapes
        shapes = new GameObject[15];
        shapes[0] = square0;
        shapes[1] = long0;
        shapes[2] = zigzag0;
        shapes[3] = square1;
        shapes[4] = long1;
        shapes[5] = zigzag1;
        shapes[6] = square2;
        shapes[7] = long2;
        shapes[8] = zigzag2;
        shapes[9] = square3;
        shapes[10] = long3;
        shapes[11] = zigzag3;
        shapes[12] = square4;
        shapes[13] = long4;
        shapes[14] = zigzag4;

        //this is the text that needs to change
        //The text here will appear in the pieces
        square0Sentence.GetComponent<TextMeshProUGUI>().text = "A";
        long0Sentence.GetComponent<TextMeshProUGUI>().text = "B";
        zigzag0Sentence.GetComponent<TextMeshProUGUI>().text = "C";
        zigzag0Sentence2.GetComponent<TextMeshProUGUI>().text = "D";
        square1Sentence.GetComponent<TextMeshProUGUI>().text = "E";
        long1Sentence.GetComponent<TextMeshProUGUI>().text = "F";
        zigzag1Sentence.GetComponent<TextMeshProUGUI>().text = "G";
        zigzag1Sentence2.GetComponent<TextMeshProUGUI>().text = "H";
        square2Sentence.GetComponent<TextMeshProUGUI>().text = "I";
        long2Sentence.GetComponent<TextMeshProUGUI>().text = "J";
        zigzag2Sentence.GetComponent<TextMeshProUGUI>().text = "K";
        zigzag2Sentence2.GetComponent<TextMeshProUGUI>().text = "L";
        square3Sentence.GetComponent<TextMeshProUGUI>().text = "M";
        long3Sentence.GetComponent<TextMeshProUGUI>().text = "N";
        zigzag3Sentence.GetComponent<TextMeshProUGUI>().text = "O";
        zigzag3Sentence2.GetComponent<TextMeshProUGUI>().text = "P";
        square4Sentence.GetComponent<TextMeshProUGUI>().text = "Q";
        long4Sentence.GetComponent<TextMeshProUGUI>().text = "R";
        zigzag4Sentence.GetComponent<TextMeshProUGUI>().text = "S";
        zigzag4Sentence2.GetComponent<TextMeshProUGUI>().text = "T";

        // this makes all the pieces turned off at the beginning
        square0.SetActive(false);
        long0.SetActive(false);
        zigzag0.SetActive(false);
        square1.SetActive(false);
        long1.SetActive(false);
        zigzag1.SetActive(false);
        square2.SetActive(false);
        long2.SetActive(false);
        zigzag2.SetActive(false);
        square3.SetActive(false);
        long3.SetActive(false);
        zigzag3.SetActive(false);
        square4.SetActive(false);
        long4.SetActive(false);
        zigzag4.SetActive(false);

        //this is the start position of the falling blocks
        //lets try it
        //Let's movea piece and see what number we get
        // a height of 364
        startPos = new Vector2(0, 0); 

        // this sets teh location of all the pieces to the starting location
        // so they can fall down when they appear 
        square0.GetComponent<RectTransform>().anchoredPosition = startPos;
        long0.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag0.GetComponent<RectTransform>().anchoredPosition = startPos;
        square1.GetComponent<RectTransform>().anchoredPosition = startPos;
        long1.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag1.GetComponent<RectTransform>().anchoredPosition = startPos;
        square2.GetComponent<RectTransform>().anchoredPosition = startPos;
        long2.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag2.GetComponent<RectTransform>().anchoredPosition = startPos;
        square3.GetComponent<RectTransform>().anchoredPosition = startPos;
        long3.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag3.GetComponent<RectTransform>().anchoredPosition = startPos;
        square4.GetComponent<RectTransform>().anchoredPosition = startPos;
        long4.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag4.GetComponent<RectTransform>().anchoredPosition = startPos;        
        
        //sets a start time to teh current time, so we can measure seconds passed
        lastTime = Time.time;

        // sets the number of random piece trys to 0
        // If there are to many tries, then we will skip
        // generating random numbers, because we want to avoid
        // the program running forever trying to pick a random number
        tryNumber = 0;
        keepSpawning = true;
    }

    // Everything in update happens about 30 times a second
    void Update()
    {
        // change from getkeydown to getkey
        // this moves pieces every time a key is pressed
        // let's change it to keep moving when you hold down the key
        // that's it
        //we need an if statement here
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //add if statement to stop it going out left side
            // what number are we checking?
            // -798           
            rect = shapes[choiceNumber].GetComponent<RectTransform>();
            //change it to 5 to make it move slower
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - 10,rect.anchoredPosition.y);
            
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //add if statement to stop it going out right side
            //What number do we need for the right side?
            //let's check
            //less than 795
            rect = shapes[choiceNumber].GetComponent<RectTransform>();
            //change it to 5 to make it move slower
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + 10,rect.anchoredPosition.y);
        }
        // this is the spawn time of the next block
        // if you set it to 3, a piece will appear every 3 seconds
        // lets set it to 2, and see what happens
        //we can make a new variable for this number called shapeSpawnWaitTime if we want it to be clearer
        if(Time.time > lastTime + 5)
        {
            //resets time to wait
            lastTime = Time.time;

            // choose a random shape to spawn
            choiceNumber = UnityEngine.Random.Range(0, 15);

            // check if all shapes have appeared
            //if all shapes on, then stop spawning shapes
            // otherwise, keep spawning shapes
            if  (   shapes[0].activeSelf == true &&
                    shapes[1].activeSelf == true &&
                    shapes[2].activeSelf == true &&
                    shapes[3].activeSelf == true &&
                    shapes[4].activeSelf == true &&
                    shapes[5].activeSelf == true &&
                    shapes[6].activeSelf == true &&
                    shapes[7].activeSelf == true &&
                    shapes[8].activeSelf == true &&
                    shapes[9].activeSelf == true &&
                    shapes[10].activeSelf == true &&
                    shapes[11].activeSelf == true &&
                    shapes[12].activeSelf == true &&
                    shapes[13].activeSelf == true &&
                    shapes[14].activeSelf == true
                )
            {
                keepSpawning = false;
            }
            else
            {
                keepSpawning = true;
            }
            // this while loop keeps choosing new numbers if the randomly chosen shape is already spawned
            while(shapes[choiceNumber].activeSelf == true && keepSpawning == true && tryNumber < 30)
            {
                choiceNumber = UnityEngine.Random.Range(0, 15);
            }
            // if the randomly chosen shape is not spawned yet, spawn it, turn it on
            if(shapes[choiceNumber].activeSelf == false && keepSpawning == true)
            {
                shapes[choiceNumber].SetActive(true);
            }
        }
    }

    // this functon gets activated by the restart button
    // it turns off all of the shapes and returns them back to their original position
    public void Restart()
    {
        square0.SetActive(false);
        long0.SetActive(false);
        zigzag0.SetActive(false);
        square1.SetActive(false);
        long1.SetActive(false);
        zigzag1.SetActive(false);
        square2.SetActive(false);
        long2.SetActive(false);
        zigzag2.SetActive(false);
        square3.SetActive(false);
        long3.SetActive(false);
        zigzag3.SetActive(false);
        square4.SetActive(false);
        long4.SetActive(false);
        zigzag4.SetActive(false);

        square0.GetComponent<RectTransform>().anchoredPosition = startPos;
        long0.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag0.GetComponent<RectTransform>().anchoredPosition = startPos;
        square1.GetComponent<RectTransform>().anchoredPosition = startPos;
        long1.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag1.GetComponent<RectTransform>().anchoredPosition = startPos;
        square2.GetComponent<RectTransform>().anchoredPosition = startPos;
        long2.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag2.GetComponent<RectTransform>().anchoredPosition = startPos;
        square3.GetComponent<RectTransform>().anchoredPosition = startPos;
        long3.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag3.GetComponent<RectTransform>().anchoredPosition = startPos;
        square4.GetComponent<RectTransform>().anchoredPosition = startPos;
        long4.GetComponent<RectTransform>().anchoredPosition = startPos;
        zigzag4.GetComponent<RectTransform>().anchoredPosition = startPos;
    }
}
