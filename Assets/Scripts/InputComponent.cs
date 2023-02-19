using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private float _playerHorizontalDirection;
    private Vector2 _mousePosition;
    private MovementComponent _myMovementComponent;
    private FeatherThrowComponent _myFeatherThrowComponent;

    // Start is called before the first frame update
    void Start()
    {
        _myMovementComponent = GetComponent<MovementComponent>();  
        _myFeatherThrowComponent = GetComponent<FeatherThrowComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerHorizontalDirection = Input.GetAxis("Horizontal");       // Se recibe Input Horizontal
        if (_playerHorizontalDirection != 0)                            // Si hay movimiento horizontal
        {
            _myMovementComponent.Move(_playerHorizontalDirection);      // Llama al m�todo Move (Horizontal) del MovementComponent
            
        }
        if (Input.GetButtonDown("Jump"))                                // Si se recibe Input de Salto
        {
            _myMovementComponent.Jump();                                // Llama al m�todo Jump del MovementComponent
        }
        if (Input.GetButtonDown("Dash"))                                // Si se recibe Input de Dash 
        {
            //_myMovementeComponent.Dash();                             // Llama al m�todo Dash del MovementComponent
        }
        if (Input.GetButtonDown("FeatherThrow"))                        // Si se recibe Input de Lanzamiento de Pluma
        {
            _mousePosition = Input.mousePosition;                       // Se guarda la posici�n del cursor
            Debug.Log("Posici�n global del rat�n:" + _mousePosition);
            _myFeatherThrowComponent.FeatherObjective(_mousePosition);
        }
    }
}
