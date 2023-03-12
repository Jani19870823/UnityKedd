using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerHO : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float angularVelocity = 20;
    [SerializeField] bool moveInCameraSpace;

    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);
        bool forward = Input.GetKey(KeyCode.W);
        bool backward = Input.GetKey(KeyCode.S);

    float z = 0;
        if (forward && backward)
            z = 0;
        else if (forward)
            z = 1;
        else if (backward)
            z = -1;

    float x = 0;
        if (left && right)
            x = 0;
        else if (left)
            x = -1;
        else if (right)
            x = 1;

    float y = 0;
        if (up && down)
            y = 0;
        else if (up)
            y = 1;
        else if (down)
            y = -1;

        Vector3 rightDir = moveInCameraSpace ? cameraTransform.right : Vector3.right;
        Vector3 forwardDir = moveInCameraSpace ? cameraTransform.forward : Vector3.forward;
        Vector3 upDir = moveInCameraSpace ? cameraTransform.up : Vector3.up;

        Vector3 velocity = rightDir * x + forwardDir * z + upDir * y;
        velocity.Normalize();

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;


        if (velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);

        }
    }
}
