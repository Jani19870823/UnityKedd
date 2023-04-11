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
        Invoke(nameof(Explode), delay); //Meghívja a robbantás (Explode) Metódust
    }

    void Explode()
    {
        Rigidbody[] allRigidbodies =FindObjectsOfType<Rigidbody>();   //egész scene-ben megkeresi és tömbbe rakja a rigidbody-kat, findobjects csak tömbben mûködik listában nem

        Vector3 selfPos = transform.position;
        foreach (Rigidbody rb in allRigidbodies)
        {
            float dist = Vector3.Distance(rb.position, selfPos);

            if (dist >= range) 
                continue;    //csak ciklusokban használható, a cikluskört megszakítja és ha van még cikluskör akkor folytatja a következõvel
            /*
            float forceRate = 1 - (dist / range);
            float currentForce = maxForce* forceRate;

            Vector3 dir = (rb.position-selfPos).normalized;
            rb.AddForce(dir, ForceMode.Impulse);

            //rb.velocity += dir * currentForce/rb.mass;  //Force.Impulse számítása
            */
            rb.AddExplosionForce(maxForce, selfPos, range, upWardModifier);  // ez ugyanaz mint a felsõ kikommentezett rész
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
