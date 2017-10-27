using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    int maxHealth;
    int currentHealth;

    public event System.Action OnHealthReachedZero;

    public virtual void Start()
    {
        currentHealth = this.maxHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (OnHealthReachedZero != null)
            {
                OnHealthReachedZero();
            }
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, this.maxHealth);
    }
}