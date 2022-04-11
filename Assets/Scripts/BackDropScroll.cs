using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDropScroll : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider; // we only want this to get the size of the object


    float scrollSpeed;
    float width;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        boxCollider.enabled = false; 
        width = boxCollider.size.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = GameManager.Instance.scrollSpeed; // we put this in start so it waits for game manager

        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f - 0.1f, 0); // the -0.1f is so the isn't a blank line between the two objects
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
