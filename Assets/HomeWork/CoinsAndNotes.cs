using UnityEngine;

class CoinsAndNotes : MonoBehaviour
{
    [SerializeField] int amount = 10000;
    [SerializeField] int notesAndCoins;

    void OnValidate()
    {
        notesAndCoins = HowManyNotes(amount);
    }


    readonly int[] notes =
        {20000,10000,5000,2000,1000,500,200,100,50,20,10,5,2,1};
    // (a readonly nem kötelezõ)

    int HowManyNotes(int num)
    {
        int result = 0;
        for (int i = notes.Length - 1; i >= 0; i--)
        {
            int noteValue = notes[i];
            result += num / noteValue;
            num = num % noteValue;
        }

        foreach (int noteValue in notes)   //Ugyanaz az eredmény mint fent
        {
            result += num / noteValue;
            num = num % noteValue;
        }


        // (foreach ciklus is használható for helyett)
        return result;
    }
}