using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformComponent : MonoBehaviour
{
    [SerializeField] private bool _moveTowardsTarget = false;
    public bool MoveTowardsTarget { get { return _moveTowardsTarget; } }

    [SerializeField] private Transform _targetPosition;
    public Transform TargetPosition { get { return _targetPosition; } }
    private Vector2 _startPosition;

    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_moveTowardsTarget)
        {
            PlatformBehaviour(_targetPosition.position);
        }
        else
        {
            PlatformBehaviour(_startPosition);
        }
    }
    public void ChangeMove()
    {
        _moveTowardsTarget = !_moveTowardsTarget;
    }

    void PlatformBehaviour(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
