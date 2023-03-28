using UnityEngine;

public class FibonacciClass : MonoBehaviour
{
    [SerializeField, Min(0)] int length = 10;
    [SerializeField] int[] array;

    void OnValidate()
    {
        array = Fibonacci(length);
    }


    int[] Fibonacci(int length)
    {
        int[] array = new int[length];

        if (length > 0)
            array[0] = 0;

        if (length > 1)
            array[1] = 1;

        for (int i = 2; i < length; i++)
        {
            array[i] = array[i - 1] + array[i - 2];
        }

        return array;
    }

}