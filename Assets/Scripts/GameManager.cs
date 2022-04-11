using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float scrollSpeed = -2f;  // move to the left
    public float platformSpeed = -3f; // move to the left
    public float gapSize = 10f;
    public event Action<int> ScoreIncreased;
    public GameObject endPanel;

    private int score;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        score = 0;
    }

    public int Score
    {
        get => score;
        set
        {
            ScoreIncreased?.Invoke(value);
            score = value;
        }
    }

    public void RestartGame(GameObject button)
    {
        button.SetActive(false);
        StartCoroutine(RestartCoroutine());
    }

    IEnumerator RestartCoroutine()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
