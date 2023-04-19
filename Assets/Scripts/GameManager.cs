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
    public int Soul { get { return _souls; } }
    private bool _isDeath = false;
    public bool IsDeath { get { return _isDeath; } }
    

    public static int _lifes = -1; //implementaar dinamica del nivel; 
    public int Lifes { get { return _lifes; } }

    private int _maxLifes;  //estaba como maxLifes = 2, pero da el error de que no se usa, en el futuro lo volvemos a añadir
    public bool _sword = false; //variable para saber si tenemos la esapda o no
    private Vector3 _respawnPoint;
    public UIManager UI;
    #endregion



    private void Awake()
    {
        if(_instance != null) _instance = this;
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
        if (_lifes > 0)
        {

            _lifes -= cant;
            _showDamage.StartCoroutine(_showDamage.ModSprite());  //animacion de daño
            _recComp.KnockBack(enemy);


            UI.QuitLifes(_lifes);
        }
        else
        {
            LoseSouls(cant, enemy);
           
            
        }
    }
    //metodo para perder almas
    public void LoseSouls(int cant, GameObject enemy)
    {
        _souls -= cant;
        Debug.Log("OK");
        _showDamage.StartCoroutine(_showDamage.ModSprite());
        _recComp.KnockBack(enemy);
        UI.QuitSouls(_souls);
    
        
    }
    public void ResetSouls()
    {
        
        _souls = 3;
        _isDeath = false;
        UI.AddAllSouls();

    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _recComp = _player.GetComponent<RecoilComponent>();
        _currentState = GameStates.TUTORIAL;
        _nextState = GameStates.TUTORIAL;
        _respawnPoint = _player.transform.position;
        UI.Evalue();
        Debug.Log(_lifes);
        

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
