using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Car : MonoBehaviour
{
    private readonly static System.Random random = new System.Random();
    private readonly float speed = random.Next(1, 100);
    private Environment environment;

    void Start()
    {
        environment = GetComponentInParent<Environment>();
    }

    void Update()
    {
        transform.position += new Vector3((100 + speed)/ 10, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObjectDestroyer"))
        {
            environment.ClearEnvironment();
            environment.SpawnObject();
        }
    }
}
