using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;


public class MovementComponent : MonoBehaviour
{
    Rigidbody2D _playerRB;
    Transform _playerTransform;

    [SerializeField] private float _rayDistance;
    [SerializeField] private float _offSet;

    [Header("Jump")]

    [SerializeField] private Transform _floorControler; //controlador del suelo
    [SerializeField] private Vector2 _floorDimensions;
    [SerializeField] private LayerMask _floor;
    [SerializeField] private float _jumpForce;

    [Header("Movement")]

    [SerializeField] private Transform _wallsController;
    [SerializeField] private Vector2 _wallsDimensions;
    [SerializeField] private LayerMask _walls;
    [SerializeField] private float _moveSpeed;


    private bool _touchingWalls;

    private bool _touchingFloor;
    public bool TouchingFloor { get { return _touchingFloor; } }
    private bool _lookingRight = true;

    [Header("Dash")]

    [SerializeField] private float _dashVelocity;
    [SerializeField] private float _timeDash;


    private float _initialGravity;
    private bool _canDash = true;
    public bool CanDash { get { return _canDash; } }

    // private bool _canMove = true; (no se usa)

    private Animator _playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
        _playerTransform = transform;
        _initialGravity = _playerRB.gravityScale;

    }
    private void Update()
    {
        _playerAnim.SetBool("onFloor", _touchingFloor);
        _playerAnim.SetFloat("Horizontal", Mathf.Abs(_playerRB.velocity.x));
        _playerAnim.SetFloat("Vertical", _playerRB.velocity.y);
        _playerAnim.SetBool("Dash", _canDash);
    }

    private void FixedUpdate()
    {
        _touchingFloor = Physics2D.OverlapBox(_floorControler.position, _floorDimensions, 0, _floor);
        _touchingWalls = Physics2D.OverlapBox(_wallsController.position, _wallsDimensions, 0, _walls);
    }
    public void Jump()
    {
        if (_touchingFloor)
        {
            _playerRB.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

    }
    public void Move(float _playerDirection)
    {
        if(!_touchingWalls)
        {
            _playerRB.velocity = new Vector2(_playerDirection * _moveSpeed, _playerRB.velocity.y);
        }
        
        if (_playerDirection > 0 && !_lookingRight)
        {
            Turn();
        }
        else if (_playerDirection < 0 && _lookingRight)
        {
            Turn();
        }

    }


    public IEnumerator Dash()
    {
        if (!_touchingFloor) // Dash only if jumping
        {
            GetComponent<InputComponent>().enabled = false;
            //_canMove = false;
            _canDash = false;
            _playerRB.gravityScale = 0;
            _playerRB.velocity = new Vector2(_dashVelocity * transform.localScale.x, 0);

            yield return new WaitForSeconds(_timeDash); //dash execution time

            _playerRB.velocity = new Vector2(0, _playerRB.velocity.y); //stop dash 
                                                                       //_canMove = true;
            _canDash = true;
            _playerRB.gravityScale = _initialGravity;
            GetComponent<InputComponent>().enabled = true;
        }
    }
    //public bool RayCast2D(float _playerDirection)
    //{
    //    Vector2 _myOffSet = new Vector2(_playerTransform.position.x, _playerTransform.position.y - _offSet); 
    //    bool _stop = false;
    //    RaycastHit2D _ray = Physics2D.Raycast(_playerTransform.position, Vector2.right * _playerDirection, _rayDistance, _walls);
    //    RaycastHit2D _rayFeet = Physics2D.Raycast(_myOffSet, Vector2.right * _playerDirection, _rayDistance, _walls);
    //    if (((_ray || _rayFeet) && _playerRB.velocity.x > 0 && Input.GetKey(KeyCode.D)) || ((_ray || _rayFeet) && _playerRB.velocity.x < 0 && Input.GetKey(KeyCode.A)))
    //    {
    //        _stop = true;
    //    }
    //    return _stop;
    //    //Debug.DrawRay(_myOffSet, Vector2.right * _playerDirection, Color.white);
    //}
    

    private void Turn()
    {
        _lookingRight = !_lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_floorControler.position, _floorDimensions);
        Gizmos.DrawWireCube(_wallsController.position, _wallsDimensions);
    }
}


