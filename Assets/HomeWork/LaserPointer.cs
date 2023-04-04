using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField] Transform[] points;

    private void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.up;

        Ray ray = new Ray(origin, direction);

        //ray.origin = origin;
        //raydirection = direction;

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);
        if (isHit)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                float t = i / (points.Length - 1f);
                point.position = Vector3.Lerp(origin, hit.point, t);
            }
        }

       foreach (Transform point in points)
        {
            point.gameObject.SetActive(isHit);

        }
    }


}
