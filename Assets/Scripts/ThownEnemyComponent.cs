using UnityEngine;

public class ThownEnemyComponent : MonoBehaviour
{

    [SerializeField] private float _movSpeed;

    [SerializeField] private int _wallLayerIndex;

    private bool _dieByWall = false;

    private float _direction = 1;

    private Rigidbody2D _rb2D;
    private Animator _animator;

    [SerializeField] private ParticleSystem _parSys;
    

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        SetSpin(-1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == _wallLayerIndex)
        {

            _dieByWall = true;
            _rb2D.velocity = Vector2.zero;
        }
    }
    private void Update()
    {
        _animator.SetBool("Death", _dieByWall);

    }

    public void SetSpin(float otherScale)
    {
        //Get direction (if boss looking right, then direction = 1, so movement to right; else direction = -1, so move to left)
        if (otherScale < 0) _direction = -1;
        Vector2 scale = transform.localScale;
        scale.x *= _direction;
        transform.localScale = scale;
        _parSys.Play();

        _rb2D.velocity = new Vector2(_movSpeed * _direction, _rb2D.velocity.y);
    }
    public void Die()
    {
        Destroy(transform.parent.gameObject);
    }

}