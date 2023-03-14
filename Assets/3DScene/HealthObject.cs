using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUi;
    // [SerializeField] Color minColor = Color.red, maxColor = Color.green;
    [SerializeField] Gradient textColor;

    [SerializeField, Min(1)] int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void Damage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    void UpdateUI()
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;

        float t = (float)currentHealth / maxHealth;

        // uiText.color = Color.Lerp(minColor, maxColor, t);
        uiText.color = textColor.Evaluate(t);

        restartUi.SetActive(!IsAlive());

    }
}