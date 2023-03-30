using UnityEngine;
public class RespawnComponent : MonoBehaviour
{
    
    private float _gravIni;
    private Rigidbody2D _rb;
    private bool _isDeath = false;
    private bool _isRespawn = false;
    
    
    void Start()
    {
        _gravIni = GetComponent<Rigidbody2D>().gravityScale;
        _rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        if (_isDeath)
        {
            Die();
        }
        if(GetComponent<MovementComponent>().TouchingFloor && _isRespawn)
        {
            Respawn();
        }
    }

    public void Die() //Desactiva componentes de player que interactuan con el mapa
    {

        GetComponent<InputComponent>().enabled = false;
        DisablePhysics();
        _rb.gravityScale = 6f;
        _rb.velocity = Vector2.zero;
        if(GetComponent<MovementComponent>().TouchingFloor)
        {
            _isRespawn = true;
        }

        /*for (int i = 0; i < transform.childCount; i++) //Desactiva componentes hijos
        {
            transform.GetChild(i).gameObject.SetActive(value: false);
        }*/
    }
    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }
    private void EnablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = true;
        }
    }
    public void ActivateDeath()
    {
        _isDeath = true;
    }
    /*public void AtivateRespawn()
    {
        _isRespawn = true;
    }*/

    public void Respawn() //Llamar cuando tengamos HUD y esas vainas
    {
        SoundComponent.Instance.PlaySound(SoundComponent.Instance._respawn);
        /*for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(value: true);
        }*/

        EnablePhysics();
        GetComponent<InputComponent>().enabled = true;
        _rb.gravityScale = _gravIni;
        GameManager.Instance.Respawne();
        _isDeath = false;
        _isRespawn = false;
        GameManager.Instance.ResetSouls();
        Debug.Log("Resp");
        
    }
}
