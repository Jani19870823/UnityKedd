using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritePrimes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WriteNPrimes(10);
    }
    void WriteNPrimes (int count)
    {
        int found = 0;
        int i = 2;
        while (found < count) 
        {
           if (IsPrime (i))
            {

                found++;
                Debug.Log(i);
            }
            i++;
        }
    }

    bool IsPrime(int number)
    {

        // Letesztelem az összes számot, 2 és n/2 közt, hogy osztó-e.
        // n/2 felett fölösleges osztót keresni
        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}