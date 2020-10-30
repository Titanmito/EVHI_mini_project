using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;

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
            if (currentHealth > 1)
            {
                currentHealth -= 1;
                healthbar.SetHealth(currentHealth);  
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            Destroy(other.gameObject);
            Destroy(GameObject.Find("doorlvl1"));
        }
        else if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
            healthbar.heal();
            currentHealth += 1;
        }
    }
}
