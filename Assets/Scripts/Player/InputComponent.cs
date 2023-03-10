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
    private ChestComponent _myChestComponent;
    [SerializeField] private float _dashCoolDown;
    private float _timeToDash = 0;
    [SerializeField]
    private float _attackRate;
    float _nextAttackTime = 0f;
    [SerializeField] private LayerMask _interactuableLayer;
    
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
            _myMovementComponent.Move(_playerHorizontalDirection);      // Llama al m?todo Move (Horizontal) del MovementComponent
        }

        else
        {
            _myMovementComponent.Move(0);
        }

        if (Input.GetButtonDown("Jump"))                                // Si se recibe Input de Salto
        {
            _myMovementComponent.Jump();                                // Llama al m?todo Jump del MovementComponent
        }

        if (Input.GetButtonDown("Dash") && _timeToDash > _dashCoolDown) // Si se recibe Input de Dash 
        {
            _myMovementComponent.StartCoroutine(_myMovementComponent.Dash());  // Llama al m?todo Dash del MovementComponent
            if (!GetComponent<MovementComponent>().CanDash)
            {
                _timeToDash = 0;
            }

        }

        if (Input.GetButtonDown("FeatherThrow"))                        // Si se recibe Input de Lanzamiento de Pluma
        {
            _mousePosition = Input.mousePosition;                       // Se guarda la posici?n del cursor

            //si direcci?n player y destino flechas son contrarios girar player
            
            
            _myFeatherThrowComponent.FeatherObjective(_mousePosition);
            if (GameManager.Instance.FeatherCant > 0)
            {
                GameManager.Instance.RemoveFeather();
            }
            
            
        }

        if(Time.time >= _nextAttackTime)
        {
            if (Input.GetButtonDown("Basic Attack") && GameManager.Instance._sword == true)
            {
                _myAttackComponent.Attack();
                _nextAttackTime = Time.time + 1f / _attackRate; //de esta forma decidimos las veces que podemos atacar por segundo
                _myMovementComponent.Move(0);
            }
        }
        

        if (Input.GetButtonDown("Interact"))
        {
            //Habr?a q ver la interacci?n del cofre desde input, de momento en el propio cofre
        }
        if(_timeToDash <= _dashCoolDown)
        {
            _timeToDash += Time.deltaTime;
        }
       

    }
}


