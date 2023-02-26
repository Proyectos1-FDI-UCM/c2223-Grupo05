using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P : MonoBehaviour
{
    [SerializeField] 
    private Transform _attackPoint;

    [SerializeField]
    private float _attackRange;

    [SerializeField]
    private LayerMask _enemylayer;
    // Update is called once per frame
    void Update()
    {
        
    }

    // play attack animation, detect enemies in range attack, damage them
    void Attack()
    {
        //animation
        Collider2D[] _hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemylayer);

        foreach(Collider2D enemies in _hitEnemies)
        {
            Debug.Log("Golpeado");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(_attackPoint== null)
        {
            return;
        }
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }


}
