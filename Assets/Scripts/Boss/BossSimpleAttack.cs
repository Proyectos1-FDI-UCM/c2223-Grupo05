using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleAttack : MonoBehaviour
{
    [SerializeField] private int _attackDamage = 1;

    [SerializeField] private Vector3 _attackOffset;
    [SerializeField] private float _attackCircle;
    [SerializeField] private LayerMask _myLayerMask;

    private void SimpleAttack()
    {
        Vector3 attackPosition = transform.position;
        attackPosition += transform.right * _attackOffset.x;
        attackPosition += transform.up * _attackOffset.y;

        Collider2D myCollision = Physics2D.OverlapCircle(attackPosition, _attackCircle, _myLayerMask);
        if (myCollision != null)
        {
            GameManager.Instance.Loselifes();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
