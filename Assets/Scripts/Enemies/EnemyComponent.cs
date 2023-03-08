using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    //Inflinge daño al player
    public enum Mele { Patrol, Spin}
    private Mele _current = Mele.Patrol;
    private Mele _nextState = Mele.Patrol;
    [SerializeField] private int _spinDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            if(_current == Mele.Patrol)
            {
                GameManager.Instance.Loselifes();
            }   
            else if(_current == Mele.Spin)
            {
                GameManager.Instance.LoseMoreThanOneLife(_spinDamage);
            }
        }
    }
    public void ChangeState(Mele state)
    {
        _nextState = state;
    }
    private void EnterState(Mele state)
    {
        switch (state)
        {
            case Mele.Patrol:
            case Mele.Spin:
                break;

        }
    }
    private void ExitState(Mele state)
    {
        switch (state)
        {
            case Mele.Patrol:
            case Mele.Spin:
                break;

        }
    }
    private void Update()
    {
        if(_nextState != _current)
        {
            ExitState(_current);
            _current= _nextState;
            EnterState(_current);
        }
    }
}
