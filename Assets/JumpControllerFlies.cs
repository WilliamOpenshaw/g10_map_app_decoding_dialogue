using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControllerFlies : MonoBehaviour
{
    public GameObject olaf1;
    public Rigidbody2D olaf1RB;

    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        olaf1RB = olaf1.GetComponent<Rigidbody2D>();
        velocity = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //olaf1RB.MovePosition(olaf1RB.position + velocity * Time.fixedDeltaTime);
        olaf1RB.MovePosition(olaf1RB.position * Time.fixedDeltaTime);
    }
}
