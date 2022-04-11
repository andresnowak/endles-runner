using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public PlatformValues[] platformSpawners;
    private Collider2D parentCollider;

    void Awake()
    {
        parentCollider = transform.parent.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Player player = other.GetComponent<Player>();

        if(other.gameObject.layer == 10)
        {
            Vector3 spawnPosition = Vector3.zero;
            PlatformValues platformChoosen = platformSpawners[Random.Range(0, platformSpawners.Length)];

            spawnPosition.x = parentCollider.bounds.max.x + GameManager.Instance.gapSize;
            spawnPosition.y = platformChoosen.positionY; // so the position in y is one we choose

            Instantiate(platformChoosen.platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
