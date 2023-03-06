using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnComponent : MonoBehaviour
{
    private Vector3 _respawnPoint;
    
    
    void Start()
    {
        _respawnPoint = transform.position;
    }

    
    public void Respawn()
    {
        transform.position = _respawnPoint;
        GameManager.Instance.ResetSouls();
        Debug.Log("Resp");
    }
    
}
