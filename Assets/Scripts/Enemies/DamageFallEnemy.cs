using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DamageFallEnemy : MonoBehaviour
{
    [SerializeField] private Transform _floorTransform;
    [SerializeField] private Vector2 _floorDimensions;
    [SerializeField] private LayerMask _floor;
    private LifeEnemyComponent _myDead;
    Rigidbody2D rb;
    float _yVelocity;
    private bool _touchingFloor;
    public bool TouchingFloor { get { return _touchingFloor; } }
    [SerializeField] private float _allowedSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        
        _myDead = GetComponent<LifeEnemyComponent>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (!_touchingFloor)
        {
            _yVelocity = rb.velocity.y;
            
        }
        else
        {
           if(_yVelocity < 3 * _allowedSpeed)
           {
                GetComponent<LifeEnemyComponent>().Die();
           }
            else if (_yVelocity < _allowedSpeed)
            {

                print("take");
                GetComponent<LifeEnemyComponent>().TakeDamage(1, 1);
                _yVelocity = 0;

            }
        }
            
        
       
    }
    private void FixedUpdate()
    {
        _touchingFloor = Physics2D.OverlapBox(_floorTransform.position, _floorDimensions, 0,_floor);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_floorTransform.position, _floorDimensions);
       
    }
}
