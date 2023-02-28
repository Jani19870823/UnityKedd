using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

     int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

   public bool IsAlive()
    {
        return currentHealth > 0;
    }
    public void Damage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);

            if (currentHealth <= 0)
            {
                Debug.Log("Goodbye");
            }
     
     // Debug.Log ("Aucs");
    }
}
