using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class BossManager : MonoBehaviour
{
    public enum BossStates {Basic, Teleport, Throw}

    private BossStates _currentState;
    private BossStates _nextState;

    #region Methods
    public void ChangeState(BossStates state)
    {
        _nextState = state;
    }
    private void EnterState(BossStates newState)
    {
        switch (newState)
        {
            case BossStates.Basic:
            case BossStates.Teleport:
            case BossStates.Throw:
                break;
        }
    }
    private void ExitState(BossStates state)
    {
        switch (state)
        {
            case BossStates.Basic:
            case BossStates.Teleport:
            case BossStates.Throw:
                break;
        }
    }
    private void UpdateState(BossStates newState)
    {
        switch (newState)
        {
            case BossStates.Basic:
            case BossStates.Teleport:
            case BossStates.Throw:
                break;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_nextState != _currentState)
        {
            ExitState(_currentState);
            _currentState = _nextState;
            EnterState(_currentState);
        }
        UpdateState(_currentState);
    }
}
