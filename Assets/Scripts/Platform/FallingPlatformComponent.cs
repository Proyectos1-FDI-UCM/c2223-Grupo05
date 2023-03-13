using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformComponent : MonoBehaviour
{
    private Rigidbody2D _myRigidBody;
    private Transform _myTransform;
    private GameObject _myPlatform;

    [Header("FALLING")]
    [SerializeField]
    private float _delay;
    [SerializeField]
    private float _amountOfShakes;

    //booleanos de control
    private bool _readyToShake;
    private bool _fall;
    //Vector auxiliar para la posicion inicial
    //private Vector2 _myOriginalPos;


    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myTransform = transform;
        _myPlatform = GetComponent<GameObject>();
        //_myOriginalPos = _myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_readyToShake)
        {
            Vector2 _shakePosition = _myTransform.position + Random.insideUnitSphere * (Time.deltaTime * _amountOfShakes);
            //_shakePosition.y = _myOriginalPos.y;

            _myTransform.position = _shakePosition;
        }
        else if (_fall)
        {
            _myRigidBody.constraints = RigidbodyConstraints2D.None;
            _myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
    }

    
    public IEnumerator Falling()
    {
        yield return new WaitForSeconds(_delay);

        _readyToShake = true;


        yield return new WaitForSeconds(_delay);

        _readyToShake = false;
        _fall = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
         
    }
    
}
