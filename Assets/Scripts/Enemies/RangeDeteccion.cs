using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDeteccion : MonoBehaviour
{
    private EnemyProjectil _projectile;
    // Start is called before the first frame update
    void Start()
    {
        _projectile= GetComponent<EnemyProjectil>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _projectile.GetComponentInParent<EnemyProjectil>().enabled = true;
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            Debug.Log("Detectado");
            _projectile.GetComponentInParent<EnemyProjectil>().enabled = true;
        }
    }
}
