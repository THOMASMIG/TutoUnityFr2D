using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float invicibilityTimeAfterHit = 3f;
    public int maxHealth = 100;
    public int currentHealth;
    public SpriteRenderer graphics;
    public float invicibilityFlashDelay = 0.15f;

    public bool isInvicible = false;

    public MyHealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealt(currentHealth);
        StartCoroutine(RegenerateHealth());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvicible = true;
            StartCoroutine(invicibilityFlash());
            StartCoroutine(invicibilityDelay());
        }
    }

    public IEnumerator RegenerateHealth()
    {
        while (true)
        {
            currentHealth = Mathf.Clamp(currentHealth + 1, -100, 100);
            healthBar.SetHealth(currentHealth);
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator invicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator invicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
