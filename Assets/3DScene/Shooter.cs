using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] KeyCode shootKey = KeyCode.Space;
    [SerializeField] GameObject projectilePrototype;
    [SerializeField] float projectileSpeed = 10;
    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            //shoot
            GameObject newBullet = Instantiate(projectilePrototype);
            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = Quaternion.LookRotation(transform.up);
            newBullet.GetComponent<Rigidbody>();
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();

            rb.velocity = transform.up * projectileSpeed;

        }
    }
}
