using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    float _playerHorizontalDirection;
    MovementComponent _myMovementeComponent;

    // Start is called before the first frame update
    void Start()
    {
        _myMovementeComponent = GetComponent<MovementComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerHorizontalDirection = Input.GetAxis("Horizontal"); // Se recibe Input Horizontal
        if (_playerHorizontalDirection != 0)    // Si hay movimiento horizontal
        {
            _myMovementeComponent.Move(_playerHorizontalDirection); // Llama al método Move (Horizontal) del MovementComponent
            
        }
        if (Input.GetButtonDown("Jump"))    // Si se recibe Input de Salto
        {
            _myMovementeComponent.Jump();   // Llama al método Jump del MovementComponent
        }
        if (Input.GetButtonDown("Dash"))   
        {
            //_myMovementeComponent.Dash();   // Llama al método Dash del MovementComponent
        }

    }
}
