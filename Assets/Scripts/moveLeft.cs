using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{

    public RectTransform rect;

    public float velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        velocity = 13.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //olaf1RB.MovePosition(olaf1RB.position + velocity * Time.fixedDeltaTime);
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - velocity,rect.anchoredPosition.y);

        if(rect.anchoredPosition.x < -1128)
        {
            rect.anchoredPosition = new Vector2(1193,rect.anchoredPosition.y);
        }
        
    }
}