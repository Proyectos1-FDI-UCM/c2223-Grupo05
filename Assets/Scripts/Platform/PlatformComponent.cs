using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformComponent : MonoBehaviour
{
    [SerializeField] private bool _canMove = false;

    [SerializeField] private Transform _targetPosition;

    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            PlatformBehaviour(_targetPosition.position);
        }
    }
    public void ChangeMove()
    {
        _canMove = !_canMove;
    }

    void PlatformBehaviour(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
