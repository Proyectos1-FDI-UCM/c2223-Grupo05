using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RespawnComponent : MonoBehaviour
{
    
    private float _gravIni;
    private Rigidbody2D _rb;
    [SerializeField] private float countdown = 0.5f;
    private float _timeAnim;
    private bool _isRespawn = false;
    private Animator _playerAnim;
    
    void Start()
    {
        _gravIni = GetComponent<Rigidbody2D>().gravityScale;
        _rb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        if (GameManager.Instance.IsDeath)
        {
            
            countdown -= Time.deltaTime;
            if (countdown > 0f)
            {
                Die();
            }
            
                if (GetComponent<MovementComponent>().TouchingFloor)
                {
                    _rb.constraints = RigidbodyConstraints2D.FreezePosition;
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
    
    

    public void Respawn() //Llamar cuando tengamos HUD y esas vainas
    {
        SoundComponent.Instance.PlaySound(SoundComponent.Instance._respawn);
        /*for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(value: true);
        }*/

        EnablePhysics();
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<InputComponent>().enabled = true;
        _rb.gravityScale = _gravIni;
        GameManager.Instance.Respawne();
       // _isRespawn = false;
        GameManager.Instance.ResetSouls();
        Debug.Log("Resp");

    }
}
