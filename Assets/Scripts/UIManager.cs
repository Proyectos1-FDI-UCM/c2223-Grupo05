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

    //[SerializeField] private 
    

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
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
