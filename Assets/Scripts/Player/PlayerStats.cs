using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxMana = 100;
    public int currentMana;
    public int attackDamage = 10;
    public int defense = 5;

    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Логика смерти игрока
    }

    public void UseMana(int amount)
    {
        currentMana -= amount;
    }
}
