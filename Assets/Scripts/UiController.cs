using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text scoreUi;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.ScoreIncreased += UpdateScoreUi;
    }

    void OnDisable()
    {
        GameManager.Instance.ScoreIncreased -= UpdateScoreUi;
    }

    void UpdateScoreUi(int newScore)
    {
        scoreUi.text = "Score: " + newScore;
    }
}
