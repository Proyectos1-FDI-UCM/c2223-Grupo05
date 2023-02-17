using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementComponent : MonoBehaviour
{
    Rigidbody2D _playerRB;

    #region toJump
    [SerializeField] private Transform _floorControler; //controlador del suelo

    [SerializeField] private Vector2 _floorDimensions;

    [SerializeField] private LayerMask _floor;

    private bool _touchingFloor;
    #endregion

    #region toMove
    /// <summary>
    /// Variables relacionadas con el movimiento del jugador
    /// </summary>
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    #endregion
    

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float _playerDirection = Input.GetAxisRaw("Horizontal");
        _touchingFloor = Physics2D.OverlapBox(_floorControler.position, _floorDimensions, 0, _floor);
        if (Input.GetKeyDown(KeyCode.Space)) Jump(); //se quita al poner el InputComponent
        if ( _playerDirection != 0) Move(_playerDirection);
    }
    void Jump()
    {
        if(_touchingFloor)
        {
            _playerRB.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

    }
    void Move(float _playerDirection)
    {
        _playerRB.velocity = new Vector2(_playerDirection * _moveSpeed, _playerRB.velocity.y);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_floorControler.position, _floorDimensions);
    }
}
