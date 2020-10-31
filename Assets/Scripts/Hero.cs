using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;

    private bool starLooted = false;
    private bool doorOpen = false;
    private bool hit = false;
    private bool healed = false;

    private float timerStar = 0.0f;
    private float invivibleStar = 10.0f;

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
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (starLooted == false)
            {
                if (currentHealth > 1)
                {
                    currentHealth -= 1;
                    healthbar.SetHealth(currentHealth);
                    hit = true;
                    red = 0;
                }
                else
                {
                    SceneManager.LoadScene("GameOver");
                }
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
                r2 -= 1;
                g2 -= 1;
                b2 -= 1;
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
                red += 1;
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
                green += 1;
                gameObject.GetComponent<Renderer>().material.color = new Color32(0, green, 0, 255);
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                green = 0;
                healed = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            Destroy(other.gameObject);
            doorOpen = true;
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
            SceneManager.LoadScene("LevelTwo");
        }
    }
}
