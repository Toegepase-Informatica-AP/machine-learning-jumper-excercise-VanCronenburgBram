using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Car : MonoBehaviour
{
    private readonly static System.Random random = new System.Random();
    private readonly float speed = random.Next(1, 100);

    void Update()
    {
        transform.position += new Vector3((100 + speed)/ 3000, 0);
    }
}
