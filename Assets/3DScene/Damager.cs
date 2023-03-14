using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;

     void OnTriggerEnter (Collider other)
    {
        // GameObject go = other.gameObject;
        // Debug.Log(go.name);

        HealthObject ho = other.GetComponent<HealthObject>();   //lekérdezi hogy az adott objektum rendelkezik-e ezzel a komponenssel, Át kell nézni a getcomponent mûködését
        /* Rigidbody rb1 = GetComponentInChildren<Rigidbody>();
         Rigidbody rb2 = GetComponentInParent<Rigidbody>();*/

        //Rigidbody[] rigidbodies = GetComponents<Rigidbody>();    //teljes objektumon ellenõriz


        if (ho!=null)
        {
            ho.Damage(damage);
        }
    }
}
