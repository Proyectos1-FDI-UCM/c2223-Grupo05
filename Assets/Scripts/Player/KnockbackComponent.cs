using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackComponent : MonoBehaviour
{
    private Rigidbody2D _playerRB;

    [Header("knockback")]
    [SerializeField]
    private float _knockbackForce;
    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KnockBack()
    {
        GetComponent<InputComponent>().enabled = false;
        Debug.Log("Entra en metodo");
        if(!GetComponent<MovementComponent>().TouchingFloor)
        {
            Debug.Log("Aire");
            _playerRB.AddForce(new Vector2(0, _knockbackForce), ForceMode2D.Impulse);
        }
        else if(GetComponent<MovementComponent>().LookingRight)
        {
            Debug.Log("derecha");
            _playerRB.AddForce(new Vector2(-_knockbackForce, _knockbackForce * 0.1f));
        }
        else
        {
            Debug.Log("izquierda");
            _playerRB.AddForce(new Vector2(_knockbackForce, _knockbackForce * 0.9f), ForceMode2D.Impulse);
        }
        ActivaInput(); //esto HAY QUE QUITARLO y activarlo CON LA ANIMACION ;3
    }
    public void ActivaInput()
    {
        GetComponent<InputComponent>().enabled = true;
    }
}
