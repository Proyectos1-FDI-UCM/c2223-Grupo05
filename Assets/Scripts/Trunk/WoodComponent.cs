using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WoodComponent : MonoBehaviour
{
    private Transform _startTransform;
    private Rigidbody2D _myRigidbody2D;

    private bool _falling = false;
    public bool Falling { get { return _falling; } set { _falling = value; } }

    [SerializeField] private float _returningVelocity;
    [SerializeField] private Transform _limitPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())
        {
            Debug.Log("Jugador la palma");
        }
    }
    private void ChangeState()
    {
        _myRigidbody2D.velocity = Vector2.zero;
        _myRigidbody2D.gravityScale = -1 * (_returningVelocity);
    } 
    // Start is called before the first frame update
    void Start()
    {
        _startTransform = transform;
        _myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_falling)
        {
            if (transform.position.y >= _limitPoint.position.y)
            {
                ChangeState();
                _falling = false;
            }
        }
    }
}
