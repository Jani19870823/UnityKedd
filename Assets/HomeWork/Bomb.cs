using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField, Min(0)] float delay = 1;
    [SerializeField] float range = 2;

    [SerializeField] float maxForce = 100;
    [SerializeField] float upWardModifier = 0.5f;

    void Start() 
    
    {
        Invoke(nameof(Explode), delay); //Megh�vja a robbant�s (Explode) Met�dust
    }

    void Explode()
    {
        Rigidbody[] allRigidbodies =FindObjectsOfType<Rigidbody>();   //eg�sz scene-ben megkeresi �s t�mbbe rakja a rigidbody-kat, findobjects csak t�mbben m�k�dik list�ban nem

        Vector3 selfPos = transform.position;
        foreach (Rigidbody rb in allRigidbodies)
        {
            float dist = Vector3.Distance(rb.position, selfPos);

            if (dist >= range) 
                continue;    //csak ciklusokban haszn�lhat�, a ciklusk�rt megszak�tja �s ha van m�g ciklusk�r akkor folytatja a k�vetkez�vel
            /*
            float forceRate = 1 - (dist / range);
            float currentForce = maxForce* forceRate;

            Vector3 dir = (rb.position-selfPos).normalized;
            rb.AddForce(dir, ForceMode.Impulse);

            //rb.velocity += dir * currentForce/rb.mass;  //Force.Impulse sz�m�t�sa
            */
            rb.AddExplosionForce(maxForce, selfPos, range, upWardModifier);  // ez ugyanaz mint a fels� kikommentezett r�sz
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
