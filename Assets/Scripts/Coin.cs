using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinPickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 10)
        {
            Debug.Log("hello");

            AudioManager.Instance.PlaySfx(coinPickup, 0.7f);

            GameManager.Instance.Score++;
            Destroy(gameObject);
        }
    }
}
