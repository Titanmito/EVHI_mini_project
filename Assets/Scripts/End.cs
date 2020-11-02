using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{

    float timeStart;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeStart > 3f)
        {
            Application.Quit();
            Debug.Log("Merci d'avoir joué");
        }
    }
}
