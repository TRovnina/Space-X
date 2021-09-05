using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public static ControllerScript instance;
    public bool isStarted = false;
    public bool end = false;

    private int _score;
    
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Button startButton;
    public GameObject menu;
    public UnityEngine.UI.Text scoreEnd;
    public UnityEngine.UI.Button endButton;
    public GameObject gameOver;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameOver.SetActive(false);
        startButton.onClick.AddListener(delegate
        {
            isStarted = true;
            menu.SetActive(false);
            Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        });

        endButton.onClick.AddListener(delegate
        {
            _score = 0;
            scoreText.text = "Score: " + _score;
            end = false;
            gameOver.SetActive(false);
            menu.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            isStarted = false;
            gameOver.SetActive(true);
            scoreEnd.text = "Your score " + _score;
        }
    }

    public void IncreaseScore(int i)
    {
        _score += i;
        scoreText.text = "Score: " + _score;
    }
}
