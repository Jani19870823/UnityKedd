using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Collector : MonoBehaviour
{
    int collected = 0;

    void OnTriggerEnter(Collider other)
    {
        Collectable c = other.GetComponent<Collectable>();
        if (c != null)
        {
            collected += c.GetValue();
            Debug.Log(collected);

            c.Teleport();
        }
    }
}
