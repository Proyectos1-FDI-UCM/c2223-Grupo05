using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatheritemComponent : MonoBehaviour
{
    private GameObject _player;
    private void Start()
    {
        _player = GameManager.Instance.SetPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            GameManager.Instance.AddFeather();
            Destroy(gameObject);
        }
    }
    
}
