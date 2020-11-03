using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{

    public Hero hero;
    public new Light light;
    public GameObject boss;
    bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hero.getLight() == true && light.intensity < 1)
        {
            light.intensity += 0.005f;
        }
        else if(light.intensity >= 1 && spawned == false)
        {
            Instantiate(boss, new Vector2(-1.2f, 0.68f), Quaternion.identity);
            spawned = true;
        }
    }
}
