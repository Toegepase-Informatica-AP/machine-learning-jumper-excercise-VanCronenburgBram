using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AutoMovement : MonoBehaviour
{

    static System.Random random = new System.Random();
    float snelheid = random.Next(1, 100);

    void Update()
    {
        transform.position += new Vector3((100 + snelheid)/ 3000, 0);
    }
}
