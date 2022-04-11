using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScroll : MonoBehaviour
{
    float movementSpeed;
    Vector3 direction = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = GameManager.Instance.platformSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementSpeed * Time.deltaTime * direction;

        Destroy();
    }

    void Destroy()
    {
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
}
