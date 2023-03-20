using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemyComponent : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;
    int _currentHealth;
    private bool _isDeath = false;


    private Animator _animator;
    private ShowDamage _showDamage;
    private RecoilComponent _recComp;
    private PatrolComponent _patrolComp;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
        _showDamage = GetComponent<ShowDamage>();
        _recComp = GetComponent<RecoilComponent>();
        _patrolComp = GetComponent<PatrolComponent>();
    }
    void Update()
    {

        if (_currentHealth <= 0)
        {
            _isDeath = true;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            
            if ((bool)this.gameObject.GetComponent<SpinComponent>()) //evaula si es mele
            {
                this.gameObject.GetComponent<SpinComponent>().enabled = false;
                _patrolComp.enabled = false;
            }
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        _animator.SetBool("Death", _isDeath); //Activa animacion de muerte y al final de la anim llama a Die()
    }
    public void TakeDamage(int damage, float playerDirection)
    {
        
        _currentHealth -= damage;
        _showDamage.StartCoroutine(_showDamage.ModSprite(this.gameObject)); //Animacion daño
        _recComp.Recoil(playerDirection);
        if ((bool)this.gameObject.GetComponent<SpinComponent>())
        {
            //_patrolComp.enabled = false;
        }
            Debug.Log(_currentHealth + "NAshe");
    }
    
    public void Die()
    {

        Destroy(gameObject);
        
    }
}
