using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class FeatherThrowComponent : MonoBehaviour
{
    private Vector2 _relativeFeatherPosition;
    private Camera _myCam;
    private Vector2 _playerScreenPosition;
    //private float _featherAngle;
  

    static private FeatherThrowComponent _instance;

    //Instancia publica del propio player para pasar posicion constante para el Return de la pluma
    static public FeatherThrowComponent Instance { get { return _instance; } } 


    [SerializeField] private GameObject _featherPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        _myCam = Camera.main;
    }

    private void Awake()
    {
        _instance = this;
    }


    //Calcula direccion de lanzaminto e instancia la pluma 
    public void FeatherObjective(Vector2 mousePosition)                   // Se calcula la posici�n donde se lanzar� la pluma
    {
        _playerScreenPosition = _myCam.WorldToScreenPoint(gameObject.transform.position);   // Posici�n del jugador en la pantalla

        _relativeFeatherPosition = mousePosition - _playerScreenPosition;   // Posici�n del rat�n respecto al jugador

        //_featherAngle = FeatherAngle(_relativeFeatherPosition);

        if (GameManager.Instance.FeatherCant > 0)                                                
        {
            Instantiate(_featherPrefab, spawnPoint.position, Quaternion.identity);
            GameManager.Instance.RemoveFeather();
        }
    }

    private float FeatherAngle(Vector2 relativeFeatherPosition)
    {
        float x = relativeFeatherPosition.y;    // x = cateto opuesto
        float y = Mathf.Sqrt(Mathf.Pow(relativeFeatherPosition.x, 2) + Mathf.Pow(relativeFeatherPosition.y, 2));    // y = hipotenusa
        float z = x / y;

        float angulo = Mathf.Asin(z);      // �ngulo = Arcoseno (x/y) em radiantes
        angulo *= Mathf.Rad2Deg;           // Pasamos el �ngulo de radiantes a grados

        return angulo;
    }
}