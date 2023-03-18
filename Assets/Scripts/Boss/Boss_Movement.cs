using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Movement : StateMachineBehaviour
{

    [SerializeField] private float _speed;
    private bool _turned;
    Vector3 flipped;

    private Transform _player;
    //private Rigidbody2D _myRigidBody2D;

    private Vector2 _playerPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        Debug.Log("Entro al estado");
        _player = GameManager.Instance.SetPlayer().transform;
        //_myRigidBody2D = animator.GetComponent<Rigidbody2D>();
        flipped = animator.transform.localScale;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Dentro del Update");
        _playerPosition = new Vector2(_player.position.x, animator.transform.position.y);
        Debug.Log(_playerPosition);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, _playerPosition, _speed * Time.fixedDeltaTime);
        LookingPlayer(animator);
        //_myRigidBody2D.MovePosition(_playerPosition);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {

    }

    private void LookingPlayer(Animator animator)
    {
        flipped.z *= -1;

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
        animator.transform.localScale = flipped;
        animator.transform.Rotate(0, 180, 0);
        _turned = !_turned;
    }
}
