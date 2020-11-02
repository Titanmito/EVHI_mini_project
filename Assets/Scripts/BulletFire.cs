using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float velocityX;
    public float velocityY;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, velocityY);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Hero"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Hero") && velocityY < 0f)
        {
            Destroy(gameObject);
        }
    }
}
