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

    private Vector3 _playerPos;

    [SerializeField] private float _speed;
    [SerializeField] private float _featherRotation;
    private bool _canReturn = false;     
    public bool CanReturn { get { return _canReturn; } }

    // Start is called before the first frame update
    void Start()
    {
       //Mirar para cambiarlo con la posición relativa del jugador

        _camera = Camera.main;
        _myRigidBody = GetComponent<Rigidbody2D>();
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = _mousePosition - transform.position;
        Vector3 rotation = transform.position - _mousePosition;

        _myRigidBody.velocity = new Vector2(direction.x, direction.y).normalized * _speed;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + _featherRotation);
    }

    // Update is called once per frame
    void Update() //Quizás nos renta más ponerlo en el fixedupdate (debido a q al fin y al cabo lo llamamos casi por las fisicas)
    {
        _playerPos = FeatherThrowComponent.Instance.spawnPoint.position;

        if (_canReturn)
        {
            Return(_playerPos);
        }
    }
    public void ActivateReturn()
    {
        _canReturn = !_canReturn;
    }       
    private void Return(Vector3 endPos)
    {
        Vector3 direction = endPos - transform.position;
        _myRigidBody.velocity = new Vector3(direction.x, direction.y).normalized * _speed;
    }
}
