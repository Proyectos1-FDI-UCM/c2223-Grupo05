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

    public int _souls = 3;
    public int _soul1;
    public int Soul { get { return _souls; } }
    private bool _isDeath = false;
    public bool IsDeath { get { return _isDeath; } }
    

    public static int _lifes = -1; //implementaar dinamica del nivel; 
    public int Lifes { get { return _lifes; } }

    private int _maxLifes;  //estaba como maxLifes = 2, pero da el error de que no se usa, en el futuro lo volvemos a a�adir
    public bool _sword = false; //variable para saber si tenemos la esapda o no
    private Vector3 _respawnPoint;
    public UIManager UI;
    private bool _canTakeDamage = true;
    public bool CanTakeDamage { set { _canTakeDamage = value ; } }
    #endregion



    private void Awake()
    {
        if(_instance == null) _instance = this;
        else Destroy(this); 
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
    
    #endregion

    //metodo para cambiar la variable de la espada a true
    public void Sword()
    {
        _sword = true;
    }
    public void AddLife()
    {
        _lifes++;
        if(_lifes > -1) {
            UI.AddLifes(_lifes); //PAra que no se salga del array en 
        }
        
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
    public void Featherslvl2()
    {
        UI.AddAllFeathers();
    }
    public void RemoveFeather()
    {
        _feathersCant--;
        UI.QuitFeathers(_feathersCant);
    }
    //metodo para perder vidas
    public void Loselifes(int cant, GameObject enemy)
    {
        SoundComponent.Instance.PlaySound(SoundComponent.Instance._playerTakesDamage);
        if (_canTakeDamage)
        {
            if (_lifes < 1) 
            {
                if(cant > 1 && _lifes > -1)  //Evalua cuando el da�o es mas de 1 y solo queda una vida
                {
                    _lifes--;
                    UI.QuitLifes(1);
                    LoseSouls(cant - 1, enemy);
                }
                else
                {
                    LoseSouls(cant, enemy);
                }  
            }
            else  //solo quita vida de cant = 2
            {
                _lifes -= cant;
                UI.QuitLifes(cant);
                _canTakeDamage = false;
                _player.GetComponent<iFramesComponent>().IFrames();
                _recComp.KnockBack(enemy);

                

            }
        }
        
    }
    //metodo para perder almas
    public void LoseSouls(int cant, GameObject enemy)
    {
        if (_canTakeDamage)
        {
            _soul1 = _souls;
            _souls -= cant;
             UI.QuitSouls(cant);
             _canTakeDamage = false;
            
            Debug.Log("OK");
            _canTakeDamage = false;
            _player.GetComponent<iFramesComponent>().IFrames();
            _recComp.KnockBack(enemy);
            
        }
        
    
        
    }
    public void ResetSouls()
    {
        
        _souls = 3;
        _isDeath = false;
        UI.AddAllSouls();

    }
    public void EvalueG()
    {
        UI.Evalue();
        Debug.Log(_lifes);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _recComp = _player.GetComponent<RecoilComponent>();
        _currentState = GameStates.TUTORIAL;
        _nextState = GameStates.TUTORIAL;
        _respawnPoint = _player.transform.position;
        EvalueG();
        

    }

    // Update is called once per frame
    void Update()
    {

        if (_souls <= 0)
        {
            _isDeath = true;
        }
        _player.GetComponent<Animator>().SetBool("Death", _isDeath);

    }
    
}
