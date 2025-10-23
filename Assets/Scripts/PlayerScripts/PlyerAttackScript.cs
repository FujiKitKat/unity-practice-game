using UnityEngine;

public class PlyerAttackScript : MonoBehaviour
{
    
    private readonly int _mouseLB = 0;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        AttackAnimation();
    }
    
    public void AttackAnimation()
    {
        if (Input.GetMouseButtonDown(_mouseLB))
        {
            _animator.SetTrigger("Attack");
        }
    }
}
