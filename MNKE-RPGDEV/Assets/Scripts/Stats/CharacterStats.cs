using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public Stat maxHealth; // Maximum amount of Health
    public int currentHealth { get; protected set; } // Current amount of health

    public Stat damage;
    public Stat armor;

    public event System.Action OnHealthReachedZero;

    public virtual void Awake()
    {
        currentHealth = maxHealth.GetValue();
    }

    //Start with max HP
    public virtual void Start()
    {

    }

    public void TakeDamage(int damage)
    {
        // Subtract the armor value - Make sure damage doesn't go below 0.
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0 ,int.MaxValue);

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
    public void Heal (int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
    }
}
