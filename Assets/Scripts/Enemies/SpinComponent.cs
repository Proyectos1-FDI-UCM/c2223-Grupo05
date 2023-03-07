using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinComponent : MonoBehaviour
{
    private Rigidbody2D _enemyRB;
    private GameObject _player;
    private PatrolComponent _patrol;

    [Header("Spin")]

    [SerializeField] private float _spinVelocity;
    [SerializeField] private float _timeSpin;
    [SerializeField] private float _timeSpin1;

    

    private bool _touchingFloor;
    public bool TouchingFloor { get { return _touchingFloor; } }

    private bool _canSpin = true;
    public bool CanSpin { get { return _canSpin; } }
    // Start is called before the first frame update
    void Start()
    {
        _player = GameManager.Instance.SetPlayer();
        _enemyRB = GetComponent<Rigidbody2D>();
        _patrol= GetComponent<PatrolComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Spin()
    {
        Vector3 _playerRelativePos = _player.transform.position - this.transform.position;
        if(_playerRelativePos.x < 0 && _patrol.lookingRight) 
        {
            _patrol.Turn();
        }
        else if(_playerRelativePos.x >0 && !_patrol.lookingRight)
        {
            _patrol.Turn();
        }
        Debug.Log("Spin");
        GetComponent<PatrolComponent>().enabled = false;
        _canSpin = false;
        
        yield return new WaitForSeconds(_timeSpin); //spin execution time
        _enemyRB.velocity = new Vector2(_spinVelocity * transform.localScale.x * (-1f), 0);

        yield return new WaitForSeconds(_timeSpin1); //spin execution time

        
        _canSpin = true;
        GetComponent<PatrolComponent>().enabled = true;
        

    }
}
