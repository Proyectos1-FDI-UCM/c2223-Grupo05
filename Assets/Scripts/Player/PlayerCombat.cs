using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerCombat : MonoBehaviour
{

    private Animator _animator;

    [Header("ATTACK")] 
    [SerializeField] 
    private Transform _attackPoint;

    [SerializeField]
    private Vector2 _attackSize;

    private float _angleAttack= 90f;

    [SerializeField]
    private CapsuleDirection2D _direction;

    [SerializeField]
    private LayerMask _enemylayer;

    [SerializeField]
    private int _attackDamage;

    

    [Header("AIR ATTACK")]

    [SerializeField]
    private float _radius;

    [Header("ILUMINATION")]
    [Range(0, 4)]
    [SerializeField] private float _attackLight;
    private Light2D _light;
    private Color _color;
    private float _intensity;
    private float _gravIni;

    private void Start()
    {
        _light = this.gameObject.GetComponentInChildren<Light2D>();
        _animator = GetComponent<Animator>();
        _color = _light.color;
        _intensity = _light.intensity;
        _gravIni = GetComponent<Rigidbody2D>().gravityScale;
    }

    // play attack animation, detect enemies in range attack, damage them
    public void Attack()
    {
        if (GetComponent<MovementComponent>().TouchingFloor)
        {
            //Se desactiva input para que no se mueva mientras ataca
            GetComponent<InputComponent>().enabled = false;

            _animator.SetTrigger("Attack");
            ActivateLight();

            Debug.Log("suelo");
            Collider2D[] _hitEnemies = Physics2D.OverlapCapsuleAll(_attackPoint.position, _attackSize, _direction, _angleAttack, _enemylayer);

            foreach (Collider2D enemies in _hitEnemies)
            {
                Debug.Log("Tocado");
                enemies.GetComponent<LifeEnemyComponent>().TakeDamage(_attackDamage);

            }
        }
        else
        {
            GetComponent<InputComponent>().enabled = false;
            Debug.Log("aire");
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ActivateLight();
            _animator.SetTrigger("Air");
            Collider2D[] _hitEnemisOnAir = Physics2D.OverlapCircleAll(_attackPoint.position, _radius, _enemylayer);



            
            foreach(Collider2D _enemiesOnAir in _hitEnemisOnAir)
            {
                Debug.Log("Tocado");
                _enemiesOnAir.GetComponent<LifeEnemyComponent>().TakeDamage(_attackDamage);
            }

        }
    }
    //Se activa al final de la animacion de ataque
    public void UnableLight()
    {
        _light.color = _color;
        _light.intensity = _intensity;
    }
    private void ActivateLight()
    {
        _light.color = Color.Lerp(_light.color, Color.white, 0.3f);
        _light.intensity = Mathf.Lerp(_light.intensity, _attackLight, 0.3f);

    }

    private void OnDrawGizmosSelected()
    {
        if(_attackPoint == null)
        {
            return;
        }

    }
    //Llamado por un event al final de la animación
    public void ActivaInput()
    {
        GetComponent<InputComponent>().enabled = true;
        GetComponent<Rigidbody2D>().gravityScale = _gravIni;
    }


}
