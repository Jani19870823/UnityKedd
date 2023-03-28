using System.Collections.Generic;
using UnityEngine;

class LetterCounter:MonoBehaviour
{
    [SerializeField] string text = "ABC";

    [SerializeField] int count = 0;

    void OnValidate()
    {
        count = CountLetters(text);

  //    List<Vector2> points = CircleDrawer.GetCirclePoints(new Vector2 (1,2), 4, 5);

  //    bool contain0 = points.Contains(Vector2.zero);
    }


    int CountLetters(string text)
    {
        List<char> characters = new List<char>();

        text = text.Replace(" ", "");

        foreach (char c in text)
        {
            if (!characters.Contains(c))
            {
                characters.Add(c);
            }
        }

        return characters.Count;
    }

}
