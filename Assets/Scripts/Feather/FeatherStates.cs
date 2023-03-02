using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FeatherStates : MonoBehaviour
{
    public enum FeatherState {FEATHER, PLATFORM, RETURN}

    private FeatherState _currentState;
   
    private FeatherState _nextState;

    private void EnterState(FeatherState state)
    {
        switch (state)
        {
            case FeatherState.FEATHER:
                this.gameObject.transform.GetChild((int)FeatherState.FEATHER).gameObject.SetActive(true);
                
                break;
            case FeatherState.PLATFORM:
                this.gameObject.transform.GetChild((int)FeatherState.PLATFORM).gameObject.SetActive(true);
<<<<<<< Updated upstream
                GetComponent<Rigidbody2D>().bodyType=  RigidbodyType2D.Static;
                GetComponent<FeatherComponent>().enabled = false;
                GetComponent<PolygonCollider2D>().enabled= false;
                transform.rotation = Quaternion.identity;             

                break;
            case FeatherState.RETURN:
=======
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                transform.rotation = Quaternion.identity;
                break;
            case FeatherState.RETURN:
                this.gameObject.transform.GetChild((int)FeatherState.RETURN).gameObject.SetActive(true);
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                this.gameObject.transform.GetChild((int)FeatherState.RETURN).gameObject.GetComponent<FeatherReturn>().ActivateReturn();
>>>>>>> Stashed changes

                break;
        }
    }
    private void ExitState(FeatherState state)
    {
        switch (state)
        {
            case FeatherState.FEATHER:
                this.gameObject.transform.GetChild((int)FeatherState.FEATHER).gameObject.SetActive(false);

                break;
            case FeatherState.PLATFORM:
                this.gameObject.transform.GetChild((int)FeatherState.PLATFORM ).gameObject.SetActive(false);
<<<<<<< Updated upstream
            
=======
                break;
            case FeatherState.RETURN:
>>>>>>> Stashed changes
                break;
        }
    }

    public void ChangeState(FeatherState newState)
    {
        _nextState = newState;
    }
    private void Awake()
    {
        this.gameObject.transform.GetChild((int)FeatherState.FEATHER).gameObject.SetActive(false);
        this.gameObject.transform.GetChild((int)FeatherState.PLATFORM).gameObject.SetActive(false);
        this.gameObject.transform.GetChild((int)FeatherState.RETURN).gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        _currentState = FeatherState.PLATFORM;
        _nextState = FeatherState.FEATHER;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_nextState != _currentState)
        {
            ExitState(_currentState);
            _currentState = _nextState;
            EnterState(_currentState);
        }
        Debug.Log(_currentState);
    }
}
