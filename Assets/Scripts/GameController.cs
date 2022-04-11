using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;

    void Start()
    {
        GameManager.Instance.endPanel.SetActive(false);

        AudioManager.Instance.PlayMusic(backgroundMusic, 0.7f);
    }
}
