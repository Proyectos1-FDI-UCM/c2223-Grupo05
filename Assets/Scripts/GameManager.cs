using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region REFERENCES
    public enum GameStates {START, TUTORIAL, LEVEL, GAMEOVER, PAUSE } //estado pause por contemplar
    //Singleton of game manager
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private GameObject _player;
    [SerializeField]private ShowDamage _showDamage;
    private RecoilComponent _recComp;
    #endregion

    #region PROPERTIES

    private GameStates _currentState;
    private GameStates _nextState;

    [SerializeField]
    private int _feathersCant; // Amount of feather that can be shot
    public  int FeatherCant { get { return _feathersCant; } }

    private int _souls = 3;
    public int Soul { get { return _souls; } }
    private bool _isDeath = false;
    

    private int _lifes = 0; //implementaar dinamica del nivel; 
    private int _maxLifes;  //estaba como maxLifes = 2, pero da el error de que no se usa, en el futuro lo volvemos a añadir
    public bool _sword = false; //variable para saber si tenemos la esapda o no
    private Vector3 _respawnPoint;
    public UIManager UI;
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
                if (_souls <= 0)
                {
                    _isDeath = true;
                }
                _player.GetComponent<Animator>().SetBool("Death", _isDeath);
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
    public void Respawne()
    {
        
        _player.transform.position = _respawnPoint;
    }
    public void Checkpoint(Vector2 respawnP)
    {
        _respawnPoint = respawnP;
    }
    public void AddFeather()
    {
        _feathersCant++;
        UI.AddFeathers(_feathersCant);
    }
    
    public void RemoveFeather()
    {
        _feathersCant--;
        UI.QuitFeathers(_feathersCant);
    }
    //metodo para perder vidas
    public void Loselifes(int cant)
    {
        SoundComponent.Instance.PlaySound(SoundComponent.Instance._playerTakesDamage);
        if (_lifes > 0)
        {

            _lifes -= cant;
            //_showDamage.StartCoroutine(_showDamage.ModSprite());  //animacion de daño


            UI.QuitLifes(_lifes);
        }
        else
        {
            LoseSouls(cant);
           
            //_player.GetComponent<ShowDamage>().StartCoroutine(_player.GetComponent<ShowDamage>().ModSprite(_player.gameObject)); //animacion de daño
        }
    }
    public void SetKnocBackToPlayer(float enemyDirection)
    {
        _recComp.StartCoroutine(_recComp.Recoil(enemyDirection * -1));
    }
    //metodo para perder almas
    public void LoseSouls(int cant)
    {
        _souls -= cant;
        Debug.Log("OK");
        _showDamage.StartCoroutine(_showDamage.ModSprite());
        UI.QuitSouls(_souls);

        
    }
    public void ResetSouls()
    {
        
        _souls = 3;
        _isDeath = false;
        UI.Addsouls(_souls);

    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _recComp = _player.GetComponent<RecoilComponent>();
        _feathersCant = 0;
        _currentState = GameStates.TUTORIAL;
        _nextState = GameStates.TUTORIAL;
        _respawnPoint = _player.transform.position;
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
