using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rigidBody;
    public float Speed = 10f;
    public KeyCode Click;
    public KeyCode Enter;
    private Vector3 startPosition;
    private Vector2 initialVelocity;    
    public bool BallPlacement;
    public Text TurnUI;
    public Text PlacementUI;


    public Vector3 getVelocity()
    {
        return initialVelocity;
    }

    private void Start()
    {
        BallPlacement = true;
        gameManager.Player1Turn = true;
        gameManager.Player2Turn = false;
        rigidBody.velocity = initialVelocity.normalized * Speed;
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallPlacement = true;
        rigidBody.position = new Vector2(-5.26f, -0.0055f);
        rigidBody.velocity = new Vector2(0f, 0f);
        PlacementUI.GetComponent<Text>().text = "Place The Ball. Press Enter When Done";
    }

    private void Update()
    {       
        if (Input.GetKey(Click) && rigidBody.velocity == Vector2.zero)
        {
            
            if (BallPlacement == true)
            {
                PlacementUI.GetComponent<Text>().text = "Place The Ball. Press Enter When Done";
                startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                startPosition.z = transform.position.z;
                rigidBody.velocity = new Vector2(0f, 0f);

                if (startPosition.x > -7.0086f && startPosition.x < -3.8586f && startPosition.y > -3.1255f && startPosition.y < 3.0845f)
                {
                    gameObject.GetComponent<Transform>().position = new Vector2(startPosition.x, startPosition.y);
                }
                else
                {
                    PlacementUI.GetComponent<Text>().text = "Cant Place The Ball There";
                }
            }

        }
        if (Input.GetKeyDown(Enter))
        {
            PlacementUI.GetComponent<Text>().text = "";
            if (BallPlacement == true && gameManager.Player1Turn == true)
            {
                BallPlacement = false;               
                TurnUI.GetComponent<Text>().text = "Player 1 Turn";
                

            }
            else if (BallPlacement == true && gameManager.Player2Turn == true)
            {
                BallPlacement = false;
                TurnUI.GetComponent<Text>().text = "Player 2 Turn";
                

            }
        }
        if (BallPlacement == false)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 Velocity = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            if (Input.GetKeyUp(Click) && rigidBody.velocity == Vector2.zero)
            {
                rigidBody.velocity = Velocity * Speed;
                if (gameManager.Player1Turn == true && gameManager.Player2Turn == false && BallPlacement == false)
                {
                    gameManager.Player1Turn = false;
                    gameManager.Player2Turn = true;
                    TurnUI.GetComponent<Text>().text = "Player 2 Turn";
                    PlacementUI.GetComponent<Text>().text = "";

                }
                else if (gameManager.Player1Turn == false && gameManager.Player2Turn == true && BallPlacement == false)
                {
                    gameManager.Player1Turn = true;
                    gameManager.Player2Turn = false;
                    TurnUI.GetComponent<Text>().text = "Player 1 Turn";
                    PlacementUI.GetComponent<Text>().text = "";
                }
            }
            
        }
    }
}












