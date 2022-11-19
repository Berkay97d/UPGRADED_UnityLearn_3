using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas inGameCanvas;

    [SerializeField] private Canvas endGameCanvas;
    [SerializeField] private TMP_Text endGameScoreText;
    [SerializeField] private TMP_Text bestScoreText;
    
    private int bestScore; 
    private int BestScore
    {
        get => bestScore;
        set
        {
            if (value > BestScore)
            {
                PlayerPrefs.SetInt("Best_Score", value);
            }
        }
    }

    [SerializeField] private TMP_Text scoreText;
   
    [SerializeField] private Image leftH;
    [SerializeField] private Image midH;
    [SerializeField] private Image rightH;

    private static int score = 0;
    private static int life = 3;


    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best_Score", 0);
    }

    private static bool IsGameOver()
    {
        return life == 0;
    }
    
    private void Update()
    {
        UpdateScoreText();
        ControlHealthUI();
        ControlUI();
    }

    private void ControlUI()
    {
        if (IsGameOver())
        {
            inGameCanvas.gameObject.SetActive(false);
            endGameCanvas.gameObject.SetActive(true);
            BestScore = score;
        }
        
        endGameScoreText.text = "Score: " + score;
        bestScoreText.text = "Best Score: " + bestScore;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public static void WinScore()
    {
        score++;
    }

    public static void LoseLife()
    {
        life--;
    }

    
    private void ControlHealthUI()
    {
        if (life == 3)
        {
            rightH.color = Color.white;
            midH.color = Color.white;
            leftH.color = Color.white;
        }
        
        if (life == 2)
        {
            rightH.color = Color.black;
        }

        if (life == 1)
        {
            midH.color = Color.black;
        }

        if (life == 0)
        {
            leftH.color = Color.black;
            GameController.isGameOver = true;
        }
        
    }

    public void RestartGame()
    {
        life = 3;
        score = 0;
        GameController.isGameOver = false;
        endGameCanvas.gameObject.SetActive(false);
        inGameCanvas.gameObject.SetActive(true);
        
    }
    
    
}
