using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProyectileComponent : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private float _maxTime;
    [SerializeField] private ParticleSystem _parSys;
    
    private void Start()
    {
        _parSys.Play();
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _maxTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            Destroy(gameObject);
            GameManager.Instance.Loselifes(1, this.gameObject);
        }
        if ((bool)collision.gameObject.GetComponent<TilemapCollider2D>() || (bool)collision.gameObject.GetComponent<FeatherWallCol>()) 
        {
            Destroy(gameObject);
        }
    }
    
}
