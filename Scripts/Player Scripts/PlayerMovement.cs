using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float moveSpeed = 2f;

    private Text scoreText;
    private int score;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //It will move towards right
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }

        //It will move towards left
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
    }// Move Control

    public void PlatformMove(float x) // it will make the player to slide move when he falls on the movePlatform 
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Platform" || target.gameObject.tag == "MovePlatform" ||
            target.gameObject.tag == "BreakPlatform")
        {
            IncrementScore();
        }
    }

    void IncrementScore()
    {
        score += 5;
        scoreText.text = score.ToString();
    }
}
