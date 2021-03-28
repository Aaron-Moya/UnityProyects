using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        loading,
        inGame,
        gameOver
    }

    public GameState gameState;
    
    private const string MAX_SCORE = "MAX_SCORE";

    public List<GameObject> tarjetPrefabs;
    private float spawnRate = 1f;

    private int numberOfLives = 4;
    public List<GameObject> lives;
    
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    private int _score;
    private int score
    {
        set
        {
            // Mantiene el score entre dos límites
            _score = Mathf.Clamp(value, 0, 99999);
        }
        get
        {
            return _score;
        }
    }

    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;

    private void Start()
    {
        ShowMaxScore();
    }

    // Método que inicia la partida 
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);

        spawnRate /= difficulty;
        numberOfLives -= difficulty;

        for (int i = 0; i < numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }
        
        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, tarjetPrefabs.Count);
            Instantiate(tarjetPrefabs[index]);
        }
    }

    // Actualiza la puntuación y los muestra por pantalla
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Max Score: \n" + "   " + maxScore;
    }

    public void UpdateMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, score);
        }

    }

    public void GameOver()
    {
        if (numberOfLives > 0)
        {
            numberOfLives--;

            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }
        
        if (numberOfLives <= 0)
        {
            UpdateMaxScore();
        
            gameState = GameState.gameOver;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
