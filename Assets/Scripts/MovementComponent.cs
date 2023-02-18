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

    private Animator _playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        //_playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _touchingFloor = Physics2D.OverlapBox(_floorControler.position, _floorDimensions, 0, _floor);

        /*if (_playerRB.velocity.x < 0.1 && _playerRB.velocity.x > -0.1)
        {
            _playerAnim.SetFloat("horizontal", _playerRB.velocity.x);
        }
        _playerAnim.SetFloat("Salto", _playerRB.velocity.y);*/
    }
    public void Jump()
    {
        if(_touchingFloor)
        {
            _playerRB.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

    }
    public void Move(float _playerDirection) //Está público para poder acceder desde el Input (Intentar cambiar)
    {
        _playerRB.velocity = new Vector2(_playerDirection * _moveSpeed, _playerRB.velocity.y);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_floorControler.position, _floorDimensions);
    }
}
