using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnComponent : MonoBehaviour
{
    private Vector3 _Respawnpoint;
    public Transform _VoidDetector;

    // Start is called before the first frame update
    void Start()
    {
        _Respawnpoint = transform.position;
    }

    //Transforma la posicion del jugador a la posicion inicla del juego
    public void Respawn()
    {
        transform.position = _Respawnpoint;
        Debug.Log("Resp");
    }
    //public void Oncheckpoint()
    //{

    //}
    // Update is called once per frame
    void Update()
    {
        _VoidDetector.position = new Vector2(transform.position.x, _VoidDetector.position.y);
    }
}
