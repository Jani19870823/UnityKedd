using System.Collections;
using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;
    [SerializeField] Gradient textColor;
    // [SerializeField] Collider hitBox;
    // [SerializeField] MeshRenderer meshRenderer;

    [SerializeField, Min(0)] float invincibilityFrames = 1;
    [SerializeField, Min(0)] float flickTime = 0.1f;

    [SerializeField, Min(1)] int maxHealth = 100;
    int currentHealth;

    bool isInvincible = false;

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
        if (isInvincible) return;
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        StartCoroutine(InvincibilityCoroutine());


        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        MeshRenderer[] allMeshRenderer = GetComponentsInChildren<MeshRenderer>();

        isInvincible = true;
        float startTime = Time.time;

        var wait = new WaitForSeconds(flickTime);

        while (startTime + invincibilityFrames > Time.time)
        {
            foreach (MeshRenderer meshRenderer in allMeshRenderer)
                meshRenderer.enabled = !meshRenderer.enabled;

            yield return wait;
        }

        foreach (MeshRenderer meshRenderer in allMeshRenderer)
            meshRenderer.enabled = true;

        isInvincible = false;
    }

    void UpdateUI()
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;

        float t = (float)currentHealth / maxHealth;

        // uiText.color = Color.Lerp(minColor, maxColor, t);
        uiText.color = textColor.Evaluate(t);

        restartUI.SetActive(!IsAlive());

    }
}