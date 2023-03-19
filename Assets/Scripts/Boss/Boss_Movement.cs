using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Movement : StateMachineBehaviour
{

    [SerializeField] private float _speed;
    private bool _turned;
    Vector3 _flipped;
    [SerializeField] private float _attackDistance = 5f;

    [SerializeField] private float _maxAttackTimer;
    private float _currentAttackTime;

    private Transform _player;
    private Vector2 _playerPosition;

    [SerializeField] private int _currentHitsToTeleport;
    [SerializeField] private int _maxHitsToTeleport;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        _player = GameManager.Instance.SetPlayer().transform;
        _flipped = animator.transform.localScale;
        _currentAttackTime = 0;
        _currentHitsToTeleport = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerPosition = new Vector2(_player.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, _playerPosition, _speed * Time.fixedDeltaTime);
        LookingPlayer(animator);

        if (Vector2.Distance(_player.transform.position, animator.transform.position) <= _attackDistance && _currentAttackTime >= _maxAttackTimer)
        {
            animator.SetTrigger("Attack");
        }

        if (_currentAttackTime >= _maxAttackTimer)
        {
            animator.SetTrigger("Teleport");
        }

        _currentAttackTime += Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        animator.ResetTrigger("Attack");
    }

    private void LookingPlayer(Animator animator)
    {
        _flipped.z *= -1;

        if (animator.transform.position.x > _player.position.x && _turned)
        {
            Turn(animator);
        }

        if (animator.transform.position.x < _player.position.x && !_turned)
        {
            Turn(animator);
        }
    }

    private void Turn(Animator animator)
    {
        animator.transform.localScale = _flipped;
        animator.transform.Rotate(0, 180, 0);
        _turned = !_turned;
    }
}
