using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemyComponent : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;
    int _currentHealth;
    private bool _isDeath = false;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        _animator.SetBool("Death", _isDeath);
        if (_currentHealth <= 0)
        {
            _isDeath = true;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.gameObject.GetComponent<PatrolComponent>().enabled = false;
            this.gameObject.GetComponent<SpinComponent>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

        }
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
       
    }
    public void Die()
    {
        //animación de muerte
        Destroy(gameObject);
    }
}
