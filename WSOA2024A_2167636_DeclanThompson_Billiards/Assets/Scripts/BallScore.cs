using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class BallScore : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rigidBody;
    public ScoreController scoreController;
    public BallController playerTurn;    
    public Text player1BallType;
    public Text player2BallType;   

    public enum BallType
    {
        whiteBall,
        stripeBall,
        solidBall,
        blackBall
    }

    public BallType ballType = BallType.whiteBall;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (gameManager.Ball1 == true && ballType == BallType.solidBall && gameManager.Player1Turn == true)
        {            
            gameManager.player1Stripe = true;
            gameManager.player2Solid = true;
            player1BallType.GetComponent<Text>().text = "Stripes";
            player2BallType.GetComponent<Text>().text = "Solids";

            rigidBody.position = new Vector2(-6.78f, -4.3695f);
            rigidBody.velocity = new Vector2(3f, 0f);

        }
        else if (gameManager.Ball1 == true && ballType == BallType.solidBall && gameManager.Player2Turn == true)
        {
            
            gameManager.player1Solid = true;
            gameManager.player2Stripe = true;
            player1BallType.GetComponent<Text>().text = "Solids";
            player2BallType.GetComponent<Text>().text = "Stripes";

            rigidBody.position = new Vector2(-6.78f, -4.3695f);
            rigidBody.velocity = new Vector2(3f, 0f);

        }
        else if (gameManager.Ball1 == true && ballType == BallType.stripeBall && gameManager.Player1Turn == true)
        {
            
            gameManager.player1Solid = true;
            gameManager.player2Stripe = true;
            player1BallType.GetComponent<Text>().text = "Solids";
            player2BallType.GetComponent<Text>().text = "Stripes";

            rigidBody.position = new Vector2(-6.78f, -4.3695f);
            rigidBody.velocity = new Vector2(3f, 0f);

        }
        else if (gameManager.Ball1 == true && ballType == BallType.stripeBall && gameManager.Player2Turn == true)
        {
            
            gameManager.player1Stripe = true;
            gameManager.player2Solid = true;
            player1BallType.GetComponent<Text>().text = "Stripes";
            player2BallType.GetComponent<Text>().text = "Solids";

            rigidBody.position = new Vector2(-6.78f, -4.3695f);
            rigidBody.velocity = new Vector2(3f, 0f);

        }       

        if (gameManager.Ball1 == true && gameManager.player1Stripe == true && gameManager.player2Solid == true)
        {
            gameManager.Ball1 = false;
        }
        else if (gameManager.Ball1 == true && gameManager.player1Solid == true && gameManager.player2Stripe == true)
        {
            gameManager.Ball1 = false;
        }

        if (gameManager.Ball1 == false && gameManager.player1Stripe == true && gameManager.player2Solid == true)
        {
            rigidBody.position = new Vector2(-6.78f, -4.3695f);
            rigidBody.velocity = new Vector2(3f, 0f);

            if (ballType == BallType.stripeBall)
            {
                gameManager.PlayerScored(1);
            }
            else if (ballType == BallType.solidBall)
            {
                gameManager.PlayerScored(2);
            }            
        }
        else if (gameManager.Ball1 == false && gameManager.player1Solid == true && gameManager.player2Stripe == true)
        {
            rigidBody.position = new Vector2(-6.78f, -4.3695f);
            rigidBody.velocity = new Vector2(3f, 0f);

            if (ballType == BallType.stripeBall)
            {
                gameManager.PlayerScored(2);
            }
            else if (ballType == BallType.solidBall)
            {
                gameManager.PlayerScored(1);
            }
            
        }
        if (ballType == BallType.blackBall && scoreController.BlackBall == false && gameManager.Player1Turn == true)
        {
            SceneManager.LoadScene(2);
        }
        else if (ballType == BallType.blackBall && scoreController.BlackBall == false && gameManager.Player2Turn == true)
        {
            SceneManager.LoadScene(3);
        }
        else if (ballType == BallType.blackBall && scoreController.BlackBall == true && gameManager.Player1Turn == true)
        {
            SceneManager.LoadScene(3);
        }
        else if (ballType == BallType.blackBall && scoreController.BlackBall == true && gameManager.Player2Turn == true)
        {
            SceneManager.LoadScene(2);
        }



    }
    
}  




