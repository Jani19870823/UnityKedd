using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Transform target;
    void Update()
    {
        Vector3 targetPosition = target.position;
        Vector3 selfPosition = transform.position; 
        
        Vector3 dir = targetPosition - selfPosition;
        if (dir !=Vector3.zero)
            transform.rotation = Quaternion.LookRotation(dir);
    }
}
