using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Logic logic;
    public Rigidbody2D myRigidbody2D;
    public float flap;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody2D.velocity = Vector2.up * flap;
        }
        if (myRigidbody2D.position.y < -25.0)
        {
            Die();
        }
        if (myRigidbody2D.position.y > 28.0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        logic.gameOver();
        isAlive = false;
    } 
}
