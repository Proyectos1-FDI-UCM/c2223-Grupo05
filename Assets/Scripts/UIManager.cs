using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _gameplayHUD;
    [SerializeField] private GameObject _retryMenu;
    [SerializeField] private GameObject _gameOverMenu;
    #endregion

    #region properties
    //array de distintos menus
    private GameObject[] _menus;
    #endregion
    #region methods
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Salir()
    {
        Debug.Log("salir");
        Application.Quit(); 
    }

    public void QuitSouls(int ind)
    {
        _souls[ind].SetActive(false);
    }
    public void Addsouls(int ind)
    {
        _souls[ind].SetActive(true);
    }
    public void QuitLifes(int ind)
    {
        _lifes[ind].SetActive(false);
    }
    public void AddLifes(int ind)
    {
        _lifes[ind].SetActive(true);
    }

    public void AddFeathers(int ind)
    {
        _feathers[ind].SetActive(true);
    }
    public void QuitFeathers(int ind)
    {
        _feathers[ind].SetActive(false);
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
