using UnityEngine;

class Gravity : MonoBehaviour
{
    [SerializeField] float acceleratin = 9.81f;
    [SerializeField] float drag = 0.2f;
    [SerializeField] KeyCode jumpButton = KeyCode.Space;
    [SerializeField] float jumpSpeed = 1f;
    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 p = transform.position;
        if (p.y >=0)
        {
            velocity += Vector3.down * acceleratin * Time.fixedDeltaTime;
            velocity -= velocity * (drag * Time.fixedDeltaTime);
            
        }
        else
        {
            p.y = 0;
            transform.position = p;
            velocity = Vector3.zero;
        }
        transform.position += velocity * Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpButton))
        {
            velocity += Vector3.up * jumpSpeed;
        }

    }
}
