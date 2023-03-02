using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FeatherStates : MonoBehaviour
{
    public enum FeatherState {FEATHER, PLATFORM, RETURN}

    [SerializeField]private FeatherState _currentState;
    public FeatherState CurrrentState { get { return _currentState; } }
   
    [SerializeField]private FeatherState _nextState;

    private void EnterState(FeatherState state)
    {

        
        switch (state)
        {
            case FeatherState.FEATHER:
                this.gameObject.transform.GetChild((int)FeatherState.FEATHER).gameObject.SetActive(true);
                
                break;
            case FeatherState.PLATFORM:
                Debug.Log("Plataformita");
                this.gameObject.transform.GetChild((int)FeatherState.PLATFORM).gameObject.SetActive(true);
                GetComponent<Rigidbody2D>().bodyType=  RigidbodyType2D.Static;
                transform.rotation = Quaternion.identity;             
                break;
          
            case FeatherState.RETURN:
                this.gameObject.transform.GetChild((int)FeatherState.RETURN).gameObject.SetActive(true);
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                this.gameObject.transform.GetChild((int)FeatherState.RETURN).gameObject.GetComponent<FeatherReturn>().ActivateReturn();
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
                break;
        }
    }

    public void ChangeState(FeatherState newState)
    {
        _nextState = newState;
        Debug.Log("new state: " + newState);
        Debug.Log("next state: " + _nextState);
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
            Debug.Log(_currentState);
            _currentState = _nextState;
            
            EnterState(_currentState);
        }
        
    }
}
