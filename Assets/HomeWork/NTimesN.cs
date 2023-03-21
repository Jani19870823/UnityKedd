using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTimesN : MonoBehaviour
{//példa segédfüggvénnyel való operálásra
    [SerializeField] int n;
    void Start()
    {
        WriteFirstNumber(n);
    }
    void WriteFirstNumber(int n)
    {
        int found = 0;
        for (int i = 1; found <n; i++) 
        {
            int sumOfDigits = SumOfDigits(i);

            if (sumOfDigits == n)
            {
                found++;
                Debug.Log(i);

            }
        }
    } 
    int SumOfDigits(int n)
    {
        int sum = 0;

        while (n>0) 
        {
            int lastDigit = n % 10;
            sum += lastDigit;
            n /= 10;
        }
        return sum;
    }
}
