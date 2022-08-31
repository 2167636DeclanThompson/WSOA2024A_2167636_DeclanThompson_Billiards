using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public Text player1ScoreDisplay;
    public Text player2ScoreDisplay;
    public bool BlackBall = false;

    private int player1Score;
    private int player2Score;

    public void PlayerScored(int playerID)
    {
        if (playerID == 1)
        {
            player1Score++;
        }
        else if (playerID == 2)
        {
            player2Score++;
        }

        UpdateScore();
        {
            if (player1Score >= 7)
            {
                BlackBall = true;
            }
            else if (player2Score >= 7)
            {
                BlackBall = true;
            }
        }
    }
    private void Start()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
        player1ScoreDisplay.text = player1Score.ToString();
        player2ScoreDisplay.text = player2Score.ToString();
    }
}
