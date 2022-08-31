using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreController scoreController;
    public BallController ballController;
    public KeyCode Escape;
    public bool Player1Turn;
    public bool Player2Turn;
    public bool Ball1 = true;
    public bool player1Stripe;
    public bool player2Stripe;
    public bool player1Solid;
    public bool player2Solid;
   public void PlayerScored(int playerID)
    {
        scoreController.PlayerScored(playerID);
    }

    public void Update()
    {
        if (Input.GetKey(Escape))
        {
            Application.Quit();
        }
    }
}
