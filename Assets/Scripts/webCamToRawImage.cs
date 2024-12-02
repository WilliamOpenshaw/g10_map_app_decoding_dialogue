using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor.Experimental.GraphView;

public class webCamToRawImage : MonoBehaviour
{
    public RawImage img = default;
    //public Texture2D tex2d;
    public WebCamTexture webcamTexture;
    public GameObject pixelReadout;
    public GameObject colorResultDisplay;    
    public String readout;

    public int width;
    public int height;
    // Start is called before the first frame update
    void Start()
    {
        pixelReadout.GetComponent<TextMeshProUGUI>().text = "0";
        // Start is called before the first frame update
    
        WebCamDevice my_device = new WebCamDevice();
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
            my_device = devices[i];
        }
        webcamTexture = new WebCamTexture(devices[0].name);
        img.texture = webcamTexture;
		img.material.mainTexture = webcamTexture;
        webcamTexture.Play();

        //img.texture = webcamTexture;
        width = webcamTexture.width;
        height = webcamTexture.height;
    }

    // Update is called once per frame
    void Update()
    {
        //width = webcamTexture.width;
        //pixelReadout.GetComponent<TextMeshProUGUI>().text = webcamTexture.GetPixel(0,0).r.ToString();
        readout = 
        " All : " +
        webcamTexture.GetPixel(0,0).ToString() + "\n" +
        " r : " +
        webcamTexture.GetPixel(0,0).r.ToString() + "\n" +
        " a : " +
        webcamTexture.GetPixel(0,0).a.ToString() + "\n" +
        " b : " +
        webcamTexture.GetPixel(0,0).b.ToString() + "\n" +
        " g : " +
        webcamTexture.GetPixel(0,0).g.ToString();

        pixelReadout.GetComponent<TextMeshProUGUI>().text = readout;

        if  
            ( 
                webcamTexture.GetPixel(0,0).r > 0.7 
                && 
                webcamTexture.GetPixel(0,0).g > 0.7 
                &&
                webcamTexture.GetPixel(0,0).b > 0.7
            )
        {
            colorResultDisplay.GetComponent<TextMeshProUGUI>().text = "WHITE";
        }
        else if  
            ( 
                //webcamTexture.GetPixel(0,0).r > 0.5 
                //&& 
                //webcamTexture.GetPixel(0,0).g < 0.4 
                //&&
                //webcamTexture.GetPixel(0,0).b < 0.4
                ((webcamTexture.GetPixel(0,0).b + webcamTexture.GetPixel(0,0).g)/2) < webcamTexture.GetPixel(0,0).r
            )
        {
            colorResultDisplay.GetComponent<TextMeshProUGUI>().text = "RED";
        }
        else if  
            ( 
                //webcamTexture.GetPixel(0,0).r < 0.4 
                //&& 
                //webcamTexture.GetPixel(0,0).g > 0.5 
                //&&
                //webcamTexture.GetPixel(0,0).b < 0.4
                ((webcamTexture.GetPixel(0,0).r + webcamTexture.GetPixel(0,0).b)/2) < webcamTexture.GetPixel(0,0).g
            )
        {
            colorResultDisplay.GetComponent<TextMeshProUGUI>().text = "GREEN";
        }
        else if  
            ( 
                //webcamTexture.GetPixel(0,0).r < 0.4 
                //&& 
                //webcamTexture.GetPixel(0,0).g < 0.4 
                //&&
                //webcamTexture.GetPixel(0,0).b > 0.4
                ((webcamTexture.GetPixel(0,0).r + webcamTexture.GetPixel(0,0).g)/2) < webcamTexture.GetPixel(0,0).b
            )
        {
            colorResultDisplay.GetComponent<TextMeshProUGUI>().text = "BLUE";
        }
        else
        {
            colorResultDisplay.GetComponent<TextMeshProUGUI>().text = "NONE";
        }
        
    }
}
