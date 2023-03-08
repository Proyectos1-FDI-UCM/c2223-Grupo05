using System.IO.Compression;
using System.Net.Http.Headers;

using Unity.VisualScripting;

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
    

    private int _lifes = 0; //implementaar dinamica del nivel; 
    private int _maxLifes;  //estaba como maxLifes = 2, pero da el error de que no se usa, en el futuro lo volvemos a añadir
    public bool _sword = false; //variable para saber si tenemos la esapda o no
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
                break;
            case GameStates.TUTORIAL:
                if(_souls <= 0){
                    _player.GetComponent<RespawnComponent>().Respawn();
                }
                break;
            case GameStates.LEVEL:
                break;
            case GameStates.GAMEOVER:
                break;
            case GameStates.PAUSE:
                break;
        }
    }
    #endregion

    //metodo para cambiar la variable de la espada a true
    public void Sword()
    {
        _sword = true;
    }
    public void AddFeather()
    {
        _feathersCant++;
        
    }
    
    public void RemoveFeather()
    {
        _feathersCant--;
    }
    //metodo para perder vidas
    public void Loselifes()
    {
        
        if (_lifes > 0)
        {

            _lifes--;
            //avisar al HUD de cambio en vidas
        }
        else
        {
            
            LoseSouls();
          
        }
    }
    public void LoseMoreThanOneLife(int num)
    {
        for(int i = 0; i < num; i++) 
        {
            Loselifes();
        }
    }
    //metodo para perder almas
    public void LoseSouls()
    {
        _souls--;


        //avisar al HUD de cambio en almas
    }
    public void ResetSouls()
    {
        _souls = 3;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _feathersCant = 0;

        _currentState = GameStates.TUTORIAL;
        _nextState = GameStates.TUTORIAL;
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
        Debug.Log(FeatherCant);
    }
    
}
