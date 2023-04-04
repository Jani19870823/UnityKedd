using System.Collections.Generic;
using UnityEngine;

class GravityModifier : MonoBehaviour
{
    [SerializeField] Vector3 gravity;

    List<Rigidbody> rigidbodies = new List<Rigidbody>();

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Add(rb);
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Remove(rb);
    }

    void FixedUpdate()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.velocity += gravity * Time.fixedDeltaTime;              // fix gyorsítás
           // rb.velocity += gravity * Time.fixedDeltaTime / rb.mass;    // fix erõ

           //----------------------------------------------------------

           // rb.AddForce(gravity, ForceMode.Acceleration);    // TÖMEG NEM SZÁMÍT   //folytonos
           // rb.AddForce(gravity, ForceMode.Force);           // TÖMEG SZÁMÍT

           // rb.AddForce(-gravity, ForceMode.VelocityChange);   // TÖMEG NEM SZÁMÍT   //Egyszeri
           // rb.AddForce(-gravity, ForceMode.Impulse);        // TÖMEG SZÁMÍT
        }
    }

}
