using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

    [SerializeField] private float _force;
    [SerializeField] private Transform _playerTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
    }
}
