using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidComponent : MonoBehaviour
{
    RespawnComponent _myRespawnComponent;
    private void Start()
    {
        _myRespawnComponent = GetComponent<RespawnComponent>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("IF");
            _myRespawnComponent.Respawn();
        }

    }
}

    
