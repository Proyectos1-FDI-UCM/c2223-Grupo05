using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnComponent : MonoBehaviour
{
    private Vector3 _respawnPoint;
    //[SerializeField ]private Transform _voidDetector;

    // Start is called before the first frame update
    void Start()
    {
        _respawnPoint = transform.position;
    }

    //Transforma la posicion del jugador a la posicion inicla del juego
    public void Respawn()
    {
        transform.position = _respawnPoint;
        Debug.Log("Resp");
    }
    //public void Oncheckpoint()
    //{

    //}
    // Update is called once per frame
    /*void Update()
    {
        _voidDetector.position = new Vector2(transform.position.x, _voidDetector.position.y);
    }*/
}
