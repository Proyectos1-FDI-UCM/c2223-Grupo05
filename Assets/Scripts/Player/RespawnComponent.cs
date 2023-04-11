using Unity.VisualScripting;
using UnityEngine;

public class RespawnComponent : MonoBehaviour
{
    
    private float _gravIni;
    private Rigidbody2D _rb;
    private float _timeAnim;
    
    void Start()
    {
        _gravIni = GetComponent<Rigidbody2D>().gravityScale;
        _rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        if (GameManager.Instance.IsDeath)
        {
            Die(); 
            if (GetComponent<MovementComponent>().TouchingFloor)
            {
                EnablePhysics();
                Physics2D.IgnoreLayerCollision(7, 9, true);
                _timeAnim += Time.deltaTime;
                if (_timeAnim > 1f)
                {
                    Respawn();
                    _timeAnim = 0f;
                }
            }
            
        }
    }

    public void Die() //Desactiva componentes de player que interactuan con el mapa
    {

        GetComponent<InputComponent>().enabled = false;
        DisablePhysics();
        _rb.gravityScale = 6f;
        _rb.velocity = Vector2.zero;
       
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
    
    

    public void Respawn() //Llamar cuando tengamos HUD y esas vainas
    {
        SoundComponent.Instance.PlaySound(SoundComponent.Instance._respawn);
        Physics2D.IgnoreLayerCollision(7, 9, false);
        GetComponent<InputComponent>().enabled = true;
        _rb.gravityScale = _gravIni;
        GameManager.Instance.Respawne();
        GameManager.Instance.ResetSouls();
        Debug.Log("Resp");

    }
}
