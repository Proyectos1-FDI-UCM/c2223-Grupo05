using UnityEngine;

public class RespawnComponent : MonoBehaviour
{
    
    private float _gravIni;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _gravIni = GetComponent<Rigidbody2D>().gravityScale;
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Die() //Desactiva componentes de player que interactuan con el mapa
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<InputComponent>().enabled = false;
        _rb.gravityScale = 0;
        _rb.velocity = Vector2.zero;
        for (int i = 0; i < transform.childCount; i++) //Desactiva componentes hijos
        {
            transform.GetChild(i).gameObject.SetActive(value: false);
        }
        
        

    }

    public void Respawn() //Llamar cuando tengamos HUD y esas vainas
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(value: true);
        }
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<InputComponent>().enabled = true;
        _rb.gravityScale = _gravIni;
        GameManager.Instance.Respawne();
        GameManager.Instance.ResetSouls();
        GetComponent<UIManager>().AddAllSouls();
        Debug.Log("Resp");
        


    }
}
