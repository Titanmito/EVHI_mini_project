using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public Vector2 target1;
    public Vector2 target2;
    Vector3 target;
    bool b = true;

    // Start is called before the first frame update
    void Start()
    {
        target = target1;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.Equals(transform.position) && b == true)
        {
            target = target1;
            b = false;
        }
        else if (target.Equals(transform.position) && b == false)
        {
            target = target2;
            b = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, 1.5f * Time.deltaTime);
    }
}
