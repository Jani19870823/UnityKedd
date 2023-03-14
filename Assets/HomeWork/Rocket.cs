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

        Vector3 direction = target.position - transform.position;   //ir�nyvektor meghat�roz�sa
        Quaternion targetRotation = Quaternion.LookRotation(direction); //ir�ny meghat�roz�sa eset�nkben a target poz�ci�ja
        float angle = angularVelocity* Time.deltaTime;  //elfordul�s sz�ge

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angle);   //r�fordul�s

        transform.position += transform.forward * speed * Time.deltaTime;   //el�rehalad�s 
    }
}
