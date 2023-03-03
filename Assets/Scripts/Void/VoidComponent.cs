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
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            collision.gameObject.GetComponent<RespawnComponent>().Respawn();
        }
    }
}

    
