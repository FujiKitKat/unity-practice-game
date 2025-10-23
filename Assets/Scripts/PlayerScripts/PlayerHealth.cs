using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 30;
    private bool _isDefend;
    private float _deadPlayerBodyDisappearingTime = 5f;
    private readonly int _mouseRB = 1;
    private Animator _animator;
    [SerializeField] Slider _HPslider;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        DefendAnimation();
    }
    
    public void TakeDamage(int damage)
    {
        if(_isDefend)
        {
            Debug.Log("Атака отбита щитом");
        }
        
        else
        {
            playerHealth -= damage;
            _HPslider.value = playerHealth;
            _animator.SetTrigger("GetHit");
            Debug.Log("Player Health is" + playerHealth);

            if (playerHealth <= 0)
            {
                _animator.SetTrigger("Death");
                Destroy(gameObject, _deadPlayerBodyDisappearingTime);
            }
        }
    }
    
    public void DefendAnimation()
    {
        //if right-click mouse then Defend effect on
        if(Input.GetMouseButtonDown(_mouseRB))
        {
            _animator.SetTrigger("Defend");
            _isDefend = true;
        }
        
        //if not right-click mouse then Defend effect off
        else if (Input.GetMouseButtonUp(_mouseRB))
        {
            _isDefend = false;
        }
    }

    public void TakeHealth(int health)
    {
        playerHealth += health;
        playerHealth = Mathf.Clamp(playerHealth, 0, 30);
        _HPslider.value = playerHealth;
        Debug.Log("Player Health is " + playerHealth);
    }
}
