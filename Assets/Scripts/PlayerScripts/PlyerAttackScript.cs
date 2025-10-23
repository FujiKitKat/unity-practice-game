using UnityEngine;

public class PlyerAttackScript : MonoBehaviour
{
    // Left mouse button index
    private readonly int _mouseLB = 0;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        // Check for attack input each frame
        AttackAnimation();
    }
    
    public void AttackAnimation()
    {
        // Trigger attack animation when left mouse button is pressed
        if (Input.GetMouseButtonDown(_mouseLB))
        {
            _animator.SetTrigger("Attack");
        }
    }
}
