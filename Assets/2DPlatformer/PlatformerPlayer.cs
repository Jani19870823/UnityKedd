using UnityEngine;

class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField, Min(0)] int airJumpCount = 1;
    [SerializeField] float movementSpeed;
    [SerializeField] Vector2 gravity = new Vector2(0, -9.81f);

    bool grounded;
    int airJumpBudget;

    void OnValidate()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded || airJumpBudget > 0)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;

                if (!grounded)
                    airJumpBudget--;
            }
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        Vector2 velocity = rb.velocity;
        velocity.x = x * movementSpeed;
        rb.velocity = velocity;

        rb.velocity += gravity * Time.fixedDeltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        airJumpBudget = airJumpCount;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
