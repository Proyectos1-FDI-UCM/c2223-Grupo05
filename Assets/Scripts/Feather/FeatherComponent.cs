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
    private GameObject _player;


    [SerializeField] private float _speed;
    [SerializeField] private float _featherRotation;
   

    // Start is called before the first frame update
    void Start()
    {
        //Mirar para cambiarlo con la posición relativa del jugador
       
        _camera = Camera.main;
        _myRigidBody = GetComponentInParent<Rigidbody2D>();
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = _mousePosition - transform.position;
        Vector3 rotation = transform.position - _mousePosition;

        _myRigidBody.velocity = new Vector2(direction.x, direction.y).normalized * _speed;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, rot + _featherRotation);
    }
}