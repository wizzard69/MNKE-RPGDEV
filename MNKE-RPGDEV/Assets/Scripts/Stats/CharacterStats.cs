using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    int maxHealth;

    public int currentHealth { get; protected set; } // Current amount of health

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

        //Subtract damage from Health
        currentHealth -= damage;

        // if we hit 0, Die
        if (currentHealth <= 0)
        {
            if (OnHealthReachedZero != null)
            {
                OnHealthReachedZero();
            }
        }
    }

    //Heal the Character
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, this.maxHealth);
    }
}