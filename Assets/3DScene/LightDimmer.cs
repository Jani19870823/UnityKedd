using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Color c1 = Color.white;
    [SerializeField] Color c2= Color.white;
    [SerializeField] float frequency = 1;

   // [SerializeField, Range(0, 1)] float dim = 0;

    private void OnValidate()
    {
        Update();
    }


    void Update()
    {
        float t = Time.time;
        t *= frequency; //a sebességet manipulálja
        t *= Mathf.PI * 2; //finomít rajta 
        float sin = Mathf.Sin(t);
        // A sinus függvényt nem engedjük negatív tartományba az alábbi mûveletsorral!
        sin += 1;
        sin /= 2;

        light.color = Color.Lerp(c1, c2, sin);
    }
}
