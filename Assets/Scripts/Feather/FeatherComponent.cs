using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FeatherComponent : MonoBehaviour
{
    private Vector3 _mousePosition;
    private Camera _camera;
    private Rigidbody2D _myRigidBody;
    [SerializeField] private LayerMask _featherRange;

    private Vector3 _direction;
    private Vector3 _rotation;
    private Vector3 _initialPos;
    [SerializeField] private float _speed;
    [SerializeField] private float _featherRotation;
    private bool _stillInRange = true;          // Innecesario de momento (Seguramente borrar)

    // Start is called before the first frame update
    void Start()
    {
        _initialPos = transform.position;

        _camera = Camera.main;
        _myRigidBody = GetComponent<Rigidbody2D>();
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        _direction = _mousePosition - transform.position;
        _rotation = transform.position - _mousePosition;

        _myRigidBody.velocity = new Vector2(_direction.x, _direction.y).normalized * _speed;

        float rot = Mathf.Atan2(_rotation.y, _rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + _featherRotation);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_stillInRange);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Fuera de rango");

            Return();
        }
    }

    void Return()
    {

        _direction = _initialPos - transform.position;
        _myRigidBody.velocity = new Vector3(_direction.x, _direction.y).normalized * _speed;
    }
}
