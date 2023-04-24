using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerComponent : MonoBehaviour
{
    private Vector2 _myCursorPosition;
    private Vector2 _myJoystickMovement;
    private Vector2 _newCursorPosition;
    private float _newX;
    private float _newY;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _myCursorPosition = Mouse.current.position.ReadDefaultValue();

        _newX = _myCursorPosition.x + (_myJoystickMovement.x * _sensitivity);
        _newY = _myCursorPosition.y + (_myJoystickMovement.y * _sensitivity);
        
        _myCursorPosition.x += _horizontal * _sensitivity;
        _myCursorPosition.y += _vertical * _sensitivity;

        _newCursorPosition = new Vector2(_newX, _newY);

        Mouse.current.WarpCursorPosition(_newCursorPosition);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined; //hace que el cursor no pueda salir de la ventana de juego
    }
    private void OnJoystickMove(InputAction.CallbackContext context)
    {
        _myJoystickMovement = context.ReadValue<Vector2>();
    }


}
