using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public int currentHealth = 2;
    private bool hit = false;
    private byte red = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 1)
        {
            Destroy(gameObject);
        }

        if (hit == true)
        {
            if (red < 255)
            {
                red += 5;
                gameObject.GetComponent<Renderer>().material.color = new Color32(red, 0, 0, 255);
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                red = 0;
                hit = false;
            }
        }
    }

    public void loseLife()
    {
        currentHealth -= 1;
        hit = true;
        red = 0;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            loseLife();
        }
    }
}
