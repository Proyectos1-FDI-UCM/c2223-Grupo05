using System.Net.Http.Headers;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Build;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region REFERENCES
    public enum GameStates {START, TUTORIAL, LEVEL, GAMEOVER, PAUSE } //estado pause por contemplar
    //Singleton of game manager
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private GameObject _player;
    #endregion

    #region PROPERTIES

    private GameStates _currentState;
    private GameStates _nextState;

    private int _feathersCant; // Amount of feather that can be shot
    public  int FeatherCant { get { return _feathersCant; } }

    private int _souls = 3;
    public int Soul { get { return _souls; } }
    

    private int _lifes; //implementaar dinamica del nivel; 
    private int _maxLifes = 2;

    #endregion



    private void Awake()
    {
        _instance = this;
    }


    #region METHODS

    public GameObject SetPlayer()
    {
        return _player;
    }
    #region STATES

    public void ChangeState(GameStates state)
    {
        _nextState = state;
    }
    private void EnterState(GameStates newState )
    {
        switch (newState)
        {
            case GameStates.START:
            case GameStates.TUTORIAL:
            case GameStates.LEVEL:
            case GameStates.GAMEOVER:
            case GameStates.PAUSE:
                break;
        }
    }
    private void ExitState(GameStates state)
    {
        switch (state)
        {
            case GameStates.START:
            case GameStates.TUTORIAL:
            case GameStates.LEVEL:
            case GameStates.GAMEOVER:
            case GameStates.PAUSE:
                break;
        }
    }
    private void UpdateState(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.START:
            case GameStates.TUTORIAL:

                if (_souls <= 0) _nextState = GameStates.GAMEOVER; //si las almas son cero actualiza al estado GameOver
                break;

            case GameStates.LEVEL:
            case GameStates.GAMEOVER:
            case GameStates.PAUSE:
                break;
        }
    }
    #endregion



    public void AddFeather()
    {
        _feathersCant++;
    }
    public void RemoveFeather()
    {
        _feathersCant--;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _feathersCant = 3; //temporal hasta introducir dinamica del tutorial de ir recogiendo las plumas una a una
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
        UpdateState(_currentState);
    }
}
