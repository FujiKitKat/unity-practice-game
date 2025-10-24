using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Character
{
    // Whether the player is currently defending with a shield
    private bool _isDefend;
    // Time before the player body disappears after death
    private float _deadPlayerBodyDisappearingTime = 5f;
    // Right mouse button index (for Input.GetMouseButton)
    private readonly int _mouseRB = 1;
    [SerializeField] Slider _HPslider;
    void Start()
    {
        _animator = GetComponent<Animator>();
        CurrentHealth = 30;
    }
    void Update()
    {
        DefendAnimation();
    }
    
    public override void TakeDamage(int damage)
    {
        // Ignore damage if defending
        if(_isDefend)
        {
            Debug.Log("The attack was defended");
        }
        
        else
        {
            // Reduce health and update UI
            base.TakeDamage(damage);
            _HPslider.value = CurrentHealth;
            _animator.SetTrigger("GetHit");
            Debug.Log("Player Health is" + CurrentHealth);

            if (CurrentHealth <= 0)
            {
                _animator.SetTrigger("Death");
                Destroy(gameObject, _deadPlayerBodyDisappearingTime);
            }
        }
    }
    
    public void DefendAnimation()
    {
        // If right mouse button pressed start defending
        if(Input.GetMouseButtonDown(_mouseRB))
        {
            _animator.SetTrigger("Defend");
            _isDefend = true;
        }
        
        else if (Input.GetMouseButtonUp(_mouseRB))
        {
            _isDefend = false;
        }
    }

    public void TakeHealth(int health)
    {
        // Heal the player
        CurrentHealth += health;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, 30);
        _HPslider.value = CurrentHealth;
        Debug.Log("Player Health is " + CurrentHealth);
    }
}
