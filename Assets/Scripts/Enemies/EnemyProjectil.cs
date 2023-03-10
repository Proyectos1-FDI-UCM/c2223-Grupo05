using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectil : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

    [SerializeField] private float _force;
    [SerializeField] private float _timeToShoot;
    [SerializeField] private float _shootCooldown;
    

    // Start is called before the first frame update
    void Start()
    {
        _shootCooldown = _timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("disparo");
        _shootCooldown -= Time.deltaTime;
        if(_shootCooldown < 0)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        GameObject arrow = Instantiate(_projectile, transform.position, Quaternion.identity);
        if (transform.localScale.x < 0)
        {
            arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(_force, 0), ForceMode2D.Force);
        }
        else
        {
            arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * _force, 0), ForceMode2D.Force);
        }
        _shootCooldown = _timeToShoot;
    }
}
