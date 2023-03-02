using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private float _playerHorizontalDirection;
    private Vector2 _mousePosition;
    private MovementComponent _myMovementComponent;
    private FeatherThrowComponent _myFeatherThrowComponent;
    private PlayerCombat _myAttackComponent;
    [SerializeField] private float _dashCoolDown;
    private float _timeToDash = 0;

    // Start is called before the first frame update
    void Start()
    {
        _myMovementComponent = GetComponent<MovementComponent>();
        _myFeatherThrowComponent = GetComponent<FeatherThrowComponent>();
        _myAttackComponent = GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerHorizontalDirection = Input.GetAxisRaw("Horizontal");       // Se recibe Input Horizontal
        if (_playerHorizontalDirection != 0)                            // Si hay movimiento horizontal
        {
            _myMovementComponent.Move(_playerHorizontalDirection);      // Llama al método Move (Horizontal) del MovementComponent
            _myMovementComponent.RayCast2D(_playerHorizontalDirection);
            if (_myMovementComponent.RayCast2D(_playerHorizontalDirection)) _myMovementComponent.Move(0);
        }
        else
        {
            _myMovementComponent.Move(0);
        }

        if (Input.GetButtonDown("Jump"))                                // Si se recibe Input de Salto
        {
            _myMovementComponent.Jump();                                // Llama al método Jump del MovementComponent
        }
        if (Input.GetButtonDown("Dash") && _timeToDash > _dashCoolDown) // Si se recibe Input de Dash 
        {
            _myMovementComponent.StartCoroutine(_myMovementComponent.Dash());  // Llama al método Dash del MovementComponent
            if (!GetComponent<MovementComponent>().CanDash)
            {
                _timeToDash = 0;
            }

        }
        if (Input.GetButtonDown("FeatherThrow"))                        // Si se recibe Input de Lanzamiento de Pluma
        {
            _mousePosition = Input.mousePosition;                       // Se guarda la posición del cursor

            //si dirección player y destino flechas son contrarios girar player

            _myFeatherThrowComponent.FeatherObjective(_mousePosition);
        }

        if (Input.GetButtonDown("Basic Attack"))
        {
            _myAttackComponent.Attack();
        }

        if (Input.GetButtonDown("Feather Return"))
        {
            //_myFeatherThrowComponent.CollectFeathers();
            // Volvemos a cambiar los estados de las plumas (accedemos a cada una del array del FeatherThrowComponent)
            // Llamamos a Return de cada FeatherComponent
        }
        _timeToDash += Time.deltaTime;

    }
}


