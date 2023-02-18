using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private float _playerHorizontalDirection;
    private Vector2 _mousePosition;
    private MovementComponent _myMovementComponent;
    private CameraComponent _myCameraComponent;

    // Start is called before the first frame update
    void Start()
    {
        _myMovementComponent = GetComponent<MovementComponent>();
        _myCameraComponent = Camera.main.gameObject.GetComponent<CameraComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerHorizontalDirection = Input.GetAxis("Horizontal"); // Se recibe Input Horizontal
        if (_playerHorizontalDirection != 0)    // Si hay movimiento horizontal
        {
            _myMovementComponent.Move(_playerHorizontalDirection); // Llama al m�todo Move (Horizontal) del MovementComponent
            
        }
        if (Input.GetButtonDown("Jump"))    // Si se recibe Input de Salto
        {
            _myMovementComponent.Jump();   // Llama al m�todo Jump del MovementComponent
        }
        if (Input.GetButtonDown("Dash"))   
        {
            //_myMovementeComponent.Dash();   // Llama al m�todo Dash del MovementComponent
        }
        if (Input.GetButtonDown("Fire2"))
        {
            _mousePosition = Input.mousePosition;
            Debug.Log(_mousePosition);
        }
    }
}
