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

        // Letesztelem az �sszes sz�mot, 2 �s n/2 k�zt, hogy oszt�-e.
        // n/2 felett f�l�sleges oszt�t keresni
        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}