using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class Hero : MonoBehaviour
{

    public int level;

    public GameObject bullet;
    public GameObject door;
    private Vector2 bulletPos;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public int maxHealth = 3;
    public int currentHealth;

    private bool starLooted = false;
    private bool doorOpen = false;
    private bool hit = false;
    private bool healed = false;

    private float timerStar = 0.0f;
    private float invivibleStar = 10.0f;
    private byte effectTime = 5;

    private byte r = 0;
    private byte g = 0;
    private byte b = 0;
    private byte r2 = 255;
    private byte g2 = 255;
    private byte b2 = 255;
    private byte red = 0;
    private byte green = 0;


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
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (starLooted == false)
            {
                currentHealth -= 1;
                healthbar.SetHealth(currentHealth);
                hit = true;
                red = 0;
            }
            
        }

        if (timerStar > 0.0f && timerStar < invivibleStar)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color32(r, g, b, 255);
            r += 10;
            g += 7;
            b += 5;
            if(r > 255)
            {
                r = 0;
            }
            timerStar += Time.deltaTime;
        }
        else if (timerStar >= invivibleStar)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
            r = 0;
            g = 0;
            b = 0;
            starLooted = false;
            timerStar = 0.0f;
        }
        if (doorOpen == true)
        {
            if (r2 > 0) 
            {
                GameObject.Find("door").GetComponent<Renderer>().material.color = new Color32(r2, g2, b2, 255);
                r2 -= effectTime;
                g2 -= effectTime;
                b2 -= effectTime;
            }
            else
            {
                Destroy(GameObject.Find("door"));
            }
        }
        if (hit == true)
        {
            if (red < 255)
            {
                red += effectTime;
                gameObject.GetComponent<Renderer>().material.color = new Color32(red, 0, 0, 255);
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                red = 0;
                hit = false;
            }
        }
        if (healed == true)
        {
            if (green < 255)
            {
                green += effectTime;
                gameObject.GetComponent<Renderer>().material.color = new Color32(0, green, 0, 255);
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                green = 0;
                healed = false;
            }
        }
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            Destroy(other.gameObject);
            doorOpen = true;
            if (level == 3)
            {
                Instantiate(door, new Vector2(2.5f,0f), Quaternion.identity);
            }
        }
        else if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            starLooted = true;
            timerStar = Time.deltaTime;
        }
        else if (other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
            healthbar.heal();
            currentHealth += 1;
            healed = true;
            green = 0;
        }
        else if (other.gameObject.CompareTag("Teleport"))
        {
            if (level == 1) 
            {
                SceneManager.LoadScene("LevelTwo");
            }
            if (level == 2)
            {
                SceneManager.LoadScene("LevelThree");
            }
            if (level == 3)
            {
                SceneManager.LoadScene("LevelFour");
            }
            if (level == 4)
            {
                SceneManager.LoadScene("LevelFive");
            }
            if (level == 5)
            {
                SceneManager.LoadScene("Congratulation");
            }

        }
        else if (other.gameObject.CompareTag("Monster"))
        {
            looseLife();
        }
        else if (other.gameObject.CompareTag("Hole"))
        {
            looseLife();
            transform.position = new Vector2(-2f, 0.9f);
        }
    }

    void looseLife()
    {
        if (starLooted == false)
        {
            currentHealth -= 1;
            healthbar.SetHealth(currentHealth);
            hit = true;
            red = 0;
        }
    }

    void fire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(+0.4f, -0.04f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
    }
}
