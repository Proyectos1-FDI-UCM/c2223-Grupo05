using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WoodComponent : MonoBehaviour
{
    private Transform _startTransform;
    private Rigidbody2D _myRigidbody2D;

    private bool _falling = false;
    private bool _returning = false;
    [SerializeField] private float _waitingSeconds = 0.5f;
    public bool Falling { get { return _falling; } set { _falling = value; } }

    [SerializeField] private float _returningVelocity;
    [SerializeField] private Transform _limitPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())
        {
            Debug.Log("Jugador la palma");
        }
    }
    private IEnumerator ChangeToReturn()
    {
        Debug.Log("Para");
        _myRigidbody2D.gravityScale = 0;
        _myRigidbody2D.velocity = Vector2.zero;

        yield return new WaitForSeconds(_waitingSeconds);

        _returning = true;

    } 
    // Start is called before the first frame update
    void Start()
    {
        _startTransform = transform;
        _myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_falling)
        {
            Debug.Log("Cayendo");
            if (transform.position.y <= _limitPoint.position.y)
            {
                _falling = false;
                StartCoroutine(ChangeToReturn());                
            }
        }
        if (_returning)
        {
            Debug.Log("Volviendo");
            Vector2.MoveTowards(transform.position, _startTransform.position, _returningVelocity * Time.deltaTime);
            if (transform.position.y >= _startTransform.position.y)
            {
                _returning = false;
            }
        }
    }
}
