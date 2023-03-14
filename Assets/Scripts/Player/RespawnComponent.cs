using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class RespawnComponent : MonoBehaviour
{
    private Vector3 _respawnPoint;
    private float _gravIni;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _gravIni = GetComponent<Rigidbody2D>().gravityScale;
        _respawnPoint = transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Die() //Desactiva componentes de player que interactuan con el mapa
    {
        for(int i = 0; i < transform.childCount; i++) //Desactiva componentes hijos
        {
            transform.GetChild(i).gameObject.SetActive(value: false);
        }
        _rb.velocity = Vector2.zero;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<InputComponent>().enabled = false;
        _rb.gravityScale = 0;

    }

    public void Respawn() //Llamar cuando tengamos HUD y esas vainas
    {
        
        GameManager.Instance.ResetSouls();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(value: true);
        }
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<InputComponent>().enabled = true;
        _rb.gravityScale = _gravIni;
        transform.position = _respawnPoint;
        Debug.Log("Resp");
    }
    
}
