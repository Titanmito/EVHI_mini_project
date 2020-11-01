using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    Vector3 target;
    bool b = true;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target.Equals(transform.position) && b == true)
        {
            target = new Vector3(2.0f, -1.0f);
            b = false;
        }
        else if (target.Equals(transform.position) && b == false)
        {
            target = new Vector3(2.0f, 1.0f);
            b = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, 1.5f * Time.deltaTime);
    }
}
