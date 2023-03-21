using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpSpeed;
    [SerializeField,Min(0)]  int airJumpCount = 1;

    bool grounded;
    int airjumpBudget;
    void OnValidate()
    {
       if (rb ==null)
            rb = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (grounded || airjumpBudget>0)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;

                if (!grounded) 
                {
                    airjumpBudget -= 1;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        grounded = true;
        airjumpBudget = airJumpCount;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
