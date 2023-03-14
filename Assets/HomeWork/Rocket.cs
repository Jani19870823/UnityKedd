using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 1;
    [SerializeField] float angularVelocity = 360;

    private void Update()
    {
        if (target == null) 
            return;

        Vector3 direction = target.position - transform.position;   //irányvektor meghatározása
        Quaternion targetRotation = Quaternion.LookRotation(direction); //irány meghatározása esetünkben a target pozíciója
        float angle = angularVelocity* Time.deltaTime;  //elfordulás szöge

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angle);   //ráfordulás

        transform.position += transform.forward * speed * Time.deltaTime;   //elõrehaladás 
    }
}
