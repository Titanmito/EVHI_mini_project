using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{

    public Boss monster;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = monster.transform.position;
        target += new Vector3(0f, 0.7f);
        transform.position = Vector3.MoveTowards(transform.position, target, 1.5f * Time.deltaTime);
    }
}
