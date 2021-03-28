using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _buttonDificulty;
    private GameManager gameManager;

    public int difficulty;
        
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _buttonDificulty = GetComponent<Button>();
        _buttonDificulty.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
