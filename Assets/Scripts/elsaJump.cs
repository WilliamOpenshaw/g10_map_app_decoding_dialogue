using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elsaJump : MonoBehaviour
{


    public float velocity;
    public float timeNow;
    public RectTransform elsaRect;

    public Vector2 ontheGround;
    public Vector2 inTheAir;
    public float jumpProgress;
    public bool up;
    // Start is called before the first frame update
    void Start()
    {
        velocity = 5.0f;        
        ontheGround = new Vector2(-694,-400);
        inTheAir = new Vector2(-694,400);
        elsaRect = gameObject.GetComponent<RectTransform>();
        jumpProgress = 0.0f;
        up = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if (Input.GetKey(KeyCode.Space) && jumpProgress <= 0.0f)
        {
            up = true;
        }
        else if(jumpProgress < 1.0f && up == true)
        {
            jumpProgress += 0.025f;
            elsaRect.anchoredPosition = Vector2.Lerp(ontheGround, inTheAir, jumpProgress);
        }
        else if (jumpProgress >= 1.0f && up == true)
        {
            up = false;
        }
        else if (jumpProgress > 0.0f && up == false)
        {
            jumpProgress -= 0.025f;
            elsaRect.anchoredPosition = Vector2.Lerp(ontheGround, inTheAir, jumpProgress);
        }  
        
    }
}
