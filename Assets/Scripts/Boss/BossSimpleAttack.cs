using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class BossSimpleAttack : MonoBehaviour
{
    [SerializeField] private int _attackDamage = 1;

    [SerializeField] private Vector3 _attackOffset;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _myLayerMask;

    public void SimpleAttack1()
    {
        Vector3 attackPosition = transform.position;
        attackPosition += transform.right * _attackOffset.x;
        attackPosition += transform.up * _attackOffset.y;

        Collider2D myCollision = Physics2D.OverlapCircle(attackPosition, _attackRadius, _myLayerMask);
        if (myCollision != null)
        {
            GameManager.Instance.Loselifes();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * _attackOffset.x;
        pos += transform.up * _attackOffset.y;

        Gizmos.DrawWireSphere(pos, _attackRadius);
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
