using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int currentHealth = 5;
    public int maxHealth = 5;
    private bool hit = false;
    private byte red = 0;

    public GameObject bullet;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    private Vector2 bulletPos;

    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 1)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Congratulation");
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

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    public void loseLife()
    {
        currentHealth -= 1;
        healthbar.SetHealth(currentHealth);
        hit = true;
        red = 0;
    }

    void fire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(+0f, -1f);
        Instantiate(bullet, bulletPos, bullet.transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            loseLife();
        }
    }
}