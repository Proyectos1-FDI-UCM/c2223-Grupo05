using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class ThownEnemyComponent : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _movSpeed;

    //[Header("FloorDetection")]
    //[SerializeField] Vector2 _fDimensions;
    //[SerializeField] private Transform _floorDetector;
    //[SerializeField] private LayerMask _floorLayer;

    [Header("WallDetection")]
    [SerializeField] Vector2 _wDimensions;
    [SerializeField] private Transform _wallDetector;
    
    [SerializeField] private int _wallLayerIndex;

    private bool _dieByWall = false;
    //private bool _dieByGround = true;
    private float _direction = 1;

    private Rigidbody2D _rb2D;
    private Animator _animator;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        SetSpin(-1);
    }

    //private void FixedUpdate()
    //{
    //    //_dieByGround = Physics2D.OverlapBox(_floorDetector.position, _fDimensions, _floorLayer);
    //    _dieByWall = Physics2D.OverlapBox(_wallDetector.position, _wDimensions, _wallLayer
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == _wallLayerIndex)
        {
            Debug.Log("no me lo cre");
            _dieByWall = true;
            _rb2D.velocity = Vector2.zero;
        }
    }
    private void Update()
    {
        _animator.SetBool("Death", _dieByWall);
        
    }

    public void SetSpin(float otherScale)
    {
        //Get direction (if boss looking right, then direction = 1, so movement to right; else direction = -1, so move to left)
        if (otherScale < 0) _direction = -1;
        Vector2 scale = transform.localScale;
        scale.x *= _direction;
        transform.localScale = scale;

        _rb2D.velocity = new Vector2(_movSpeed * _direction, _rb2D.velocity.y);
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawWireCube(_floorDetector.position, _fDimensions);
        Gizmos.DrawWireCube(_wallDetector.position, _wDimensions);
    }
}
