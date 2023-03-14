using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDeteccion : MonoBehaviour
{
    [Header("Range")]

    [SerializeField] private Transform _rangeControler; //controlador del suelo
    [SerializeField] private float _rangeRadius;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _timeToShoot;
    [SerializeField] private float _shootCooldown;

    private Animator _animator;
    private bool _detection;
    

    private EnemyShoot _projectile;
    // Start is called before the first frame update
    void Start()
    {
        _projectile= GetComponent<EnemyShoot>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _detection = Physics2D.OverlapCircle(_rangeControler.position, _rangeRadius , _playerLayer);
    }
    private void Update()
    {
       
        if (_detection && _timeToShoot > _shootCooldown )
        {
            Debug.Log("Detectado");

            _animator.SetTrigger("ShootCharge");
            _projectile.GetComponentInParent<EnemyShoot>().Shoot();
            
            _timeToShoot = 0;
        }
        if(_timeToShoot <= _shootCooldown)
        {
            _timeToShoot += Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_rangeControler.position, _rangeRadius);
    }
}
