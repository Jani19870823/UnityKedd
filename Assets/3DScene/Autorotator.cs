using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autorotator : MonoBehaviour
{
    [SerializeField] float angularVelocity = 360;
    [SerializeField] Vector3 axis = Vector3.up;
    [SerializeField] Space rotationSpace; 
    void Update()
    {
        //Vector3 euler = new Vector3(0, angularVelocity, 0);
        //euler *= Time.deltaTime;
        transform.Rotate(axis, angularVelocity * Time.deltaTime, rotationSpace);
    }

    void OnDrawGizmos()
    {
        Vector3 center = transform.position;

        Vector3 dir = axis.normalized;

        if (rotationSpace == Space.World)
        {
            dir = axis.normalized;
        }
        else
        {
            dir = transform.TransformDirection(axis).normalized;
        }
        Vector3 a = center + dir*2;
        Vector3 b = center - dir*2;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(a, b);

    }
}
