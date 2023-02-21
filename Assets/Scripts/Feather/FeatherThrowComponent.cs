using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class FeatherThrowComponent : MonoBehaviour
{
    private Vector2 _relativeFeatherPosition;
    private Camera _myCam;
    private Vector2 _playerScreenPosition;
    private float _featherAngle;
    // private int _featherCounter = 3;   (ya se hará)

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

    public void FeatherObjective(Vector2 mousePosition)                   // Se calcula la posición donde se lanzará la pluma
    {
        _playerScreenPosition = _myCam.WorldToScreenPoint(gameObject.transform.position);   // Posición del jugador en la pantalla

        _relativeFeatherPosition = mousePosition - _playerScreenPosition;   // Posición del ratón respecto al jugador

        _featherAngle = FeatherAngle(_relativeFeatherPosition);

        Instantiate(_featherPrefab, spawnPoint.position, Quaternion.identity);

        /*if (_featherCounter > 0)                                                // Esto va en el GameManager (?????) (temporal)
        {
            Instantiate(_featherPrefab, _spawnPoint.position, Quaternion.identity);
            _featherCounter--;
        }*/
    }

    private float FeatherAngle(Vector2 relativeFeatherPosition)
    {
        float x = relativeFeatherPosition.y;    // x = cateto opuesto
        float y = Mathf.Sqrt(Mathf.Pow(relativeFeatherPosition.x, 2) + Mathf.Pow(relativeFeatherPosition.y, 2));    // y = hipotenusa
        float z = x / y;

        float angulo = Mathf.Asin(z);      // Ángulo = Arcoseno (x/y) em radiantes
        angulo *= Mathf.Rad2Deg;           // Pasamos el ángulo de radiantes a grados

        return angulo;
    }
}