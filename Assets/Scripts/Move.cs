using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.Q) == true)
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            movement += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Z) == true)
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.Escape) == true)
        {
            Application.Quit();
        }

            transform.position += movement * speed * Time.deltaTime;
    }
}
