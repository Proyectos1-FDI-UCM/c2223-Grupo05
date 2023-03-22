using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    #region references
    [SerializeField] private TMP_Text _move;
    [SerializeField] private TMP_Text _jump;
    [SerializeField] private TMP_Text _interact;
    [SerializeField] private TMP_Text _feather;
    [SerializeField] private TMP_Text _dash;
    [SerializeField] private TMP_Text _sword;
    [SerializeField] private TMP_Text _button;

    
    public GameObject[] _souls;
    public GameObject[] _lifes;
    public GameObject[] _feathers;

    

    //MENUS
    //[SerializeField] private GameObject _startMenu;
    //[SerializeField] private GameObject _gameplayHUD;
    [SerializeField] private GameObject _pauseMenu;
    //[SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private AudioMixer _audioMixer;
    #endregion

    #region properties
    //array de distintos menus
    private GameObject[] _menus;
    #endregion
    #region methods MenuInicial
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void Salir()
    {
        Debug.Log("salir");
        Application.Quit(); 
    }
    #endregion
    #region methods
    public void QuitSouls(int ind)
    {
        _souls[ind].SetActive(false);
    }
    public void Addsouls(int ind)
    {
        _souls[ind - 1].SetActive(true);
    }
    public void QuitLifes(int ind)
    {
        _lifes[ind - 1].SetActive(false);
    }
    public void AddLifes(int ind)
    {
        _lifes[ind - 1].SetActive(true);
    }

    public void AddFeathers(int ind)
    {
        _feathers[ind - 1].SetActive(true);
    }
    public void QuitFeathers(int ind)
    {
        _feathers[ind].SetActive(false);
    }
    public void AddAllSouls()
    {
        _souls[0].SetActive(true);
        _souls[1].SetActive(true);
        _souls[2].SetActive(true);

    }
    #endregion
    #region methods MenuOpciones
    public void FullScreen(bool _fullScreen)
    {
        Screen.fullScreen = _fullScreen;
    }
    public void ChangeVolume(float _volume)
    {
        _audioMixer.SetFloat("Volumen", _volume);
        _audioMixer.SetFloat("Music", _volume);
        _audioMixer.SetFloat("Effects", _volume);
    }
    #endregion
    #region methods MenuPause
    public void Pause()
    {
        
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);      
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _feathers[0].SetActive(false);
        _feathers[1].SetActive(false);
        _feathers[2].SetActive(false);
        _lifes[0].SetActive(false);
        _lifes[1].SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
