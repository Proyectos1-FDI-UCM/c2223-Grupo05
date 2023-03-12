using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProyectileComponent : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private float _maxTime;
    // Start is called before the first frame update
    void Start()
    {
        
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
            GameManager.Instance.Loselifes();
        }
        if((bool)collision.gameObject.GetComponent<TilemapCollider2D>())
        {
            Destroy(gameObject);
        }
    }
    
}
