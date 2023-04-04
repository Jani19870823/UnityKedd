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
            rb.velocity += gravity * Time.fixedDeltaTime;              // fix gyors�t�s
           // rb.velocity += gravity * Time.fixedDeltaTime / rb.mass;    // fix er�

           //----------------------------------------------------------

           // rb.AddForce(gravity, ForceMode.Acceleration);    // T�MEG NEM SZ�M�T   //folytonos
           // rb.AddForce(gravity, ForceMode.Force);           // T�MEG SZ�M�T

           // rb.AddForce(-gravity, ForceMode.VelocityChange);   // T�MEG NEM SZ�M�T   //Egyszeri
           // rb.AddForce(-gravity, ForceMode.Impulse);        // T�MEG SZ�M�T
        }
    }

}
