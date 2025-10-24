using UnityEngine;

public class Character : MonoBehaviour
{
    private int _currentHealth;
    protected Animator _animator;

    public int CurrentHealth
    {
        get => _currentHealth; 
        set => _currentHealth = value;
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
