using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] 
    private Transform _attackPoint;

    [SerializeField]
    private Vector2 _attackSize;

    private float _angleAttack= 90f;

    [SerializeField]
    private CapsuleDirection2D _direction;

    [SerializeField]
    private LayerMask _enemylayer;

    [SerializeField]
    private int _attackDamage;

    // Update is called once per frame
    void Update()
    {
        
    }

    // play attack animation, detect enemies in range attack, damage them
    public void Attack()
    {
        
        //animation
        if (GetComponent<MovementComponent>().TouchingFloor)
        {
            GetComponent<InputComponent>().enabled = false;
            Debug.Log("suelo");
            Collider2D[] _hitEnemies = Physics2D.OverlapCapsuleAll(_attackPoint.position, _attackSize, _direction, _angleAttack, _enemylayer);

            foreach (Collider2D enemies in _hitEnemies)
            {
                Debug.Log("Tocado");
                enemies.GetComponent<LifeEnemyComponent>().TakeDamage(_attackDamage);

            }
            GetComponent<InputComponent>().enabled = true;
        }
        
        
    }

    private void OnDrawGizmosSelected()
    {
        if(_attackPoint== null)
        {
            return;
        }

    }


}
