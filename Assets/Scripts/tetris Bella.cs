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
    
    // Start is called before the first frame update
    void Start()
    {
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

        //
        square0Sentence.GetComponent<TextMeshProUGUI>().text = "The cat fell";
        long0Sentence.GetComponent<TextMeshProUGUI>().text = "The cat is sleeping";
        zigzag0Sentence.GetComponent<TextMeshProUGUI>().text = "A little bit ";
        zigzag0Sentence2.GetComponent<TextMeshProUGUI>().text = "of fun";
        square1Sentence.GetComponent<TextMeshProUGUI>().text = "Kitten bell ring";
        long1Sentence.GetComponent<TextMeshProUGUI>().text = "Curiosity killed the cat";
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

        startPos = new Vector2(0, 0); 

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

        lastTime = Time.time;

        tryNumber = 0;
        keepSpawning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rect = shapes[choiceNumber].GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - 10,rect.anchoredPosition.y);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            rect = shapes[choiceNumber].GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + 10,rect.anchoredPosition.y);
        }
        if(Time.time > lastTime + 5)
        {
            lastTime = Time.time;
            choiceNumber = UnityEngine.Random.Range(0, 15);
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
            while(shapes[choiceNumber].activeSelf == true && keepSpawning == true && tryNumber < 30)
            {
                choiceNumber = UnityEngine.Random.Range(0, 15);
            }
            if(shapes[choiceNumber].activeSelf == false && keepSpawning == true)
            {
                shapes[choiceNumber].SetActive(true);
            }
        }
    }

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
