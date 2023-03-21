using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeanArray : MonoBehaviour
{
    [SerializeField] float[] floats;
    [SerializeField] float mean;
    private void OnValidate()
    {
        mean = Mean(floats);
    }



    float Mean(float[] array)

    {
        float mean = 0;
        foreach (float n in array) 
        {
            mean += n;
        }

        mean/=array.Length;

        return mean;
    }
}
