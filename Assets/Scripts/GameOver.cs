using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioClip endMusic;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 10)
        {
            GameManager.Instance.endPanel.SetActive(true);
            AudioManager.Instance.PlayMusic(endMusic, 0.7f);

            Destroy(other.gameObject);
        }
    }
}
