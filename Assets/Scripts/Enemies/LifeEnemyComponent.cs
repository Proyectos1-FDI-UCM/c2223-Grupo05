using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemyComponent : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;
    int _currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //animación de muerte
        Destroy(gameObject);
    }
}
