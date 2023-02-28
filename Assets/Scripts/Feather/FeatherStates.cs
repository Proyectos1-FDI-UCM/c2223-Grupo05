using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FeatherStates : MonoBehaviour
{
    public enum FeatherState {FEATHER, PLATFORM}

    public FeatherState _currentState;
    private FeatherState _nextState;

    private void EnterState(FeatherState state)
    {
        switch (state)
        {
            case FeatherState.FEATHER:


                break;
            case FeatherState.PLATFORM:


                break;
        }
    }
    private void ExitState(FeatherState state)
    {
        switch (state)
        {
            case FeatherState.FEATHER:


                break;
            case FeatherState.PLATFORM:


                break;
        }
    }

    public void ChangeState(FeatherState newState)
    {
        _nextState = newState;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
