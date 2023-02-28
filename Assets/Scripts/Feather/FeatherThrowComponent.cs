using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class FeatherThrowComponent : MonoBehaviour
{
    private Vector2 _relativeFeatherPosition;
    private Camera _myCam;
    private Vector2 _playerScreenPosition;
     [SerializeField] private GameObject[] _featherArray = new GameObject[3];
    //private float _featherAngle;
  

    

    //Instancia publica del propio player para pasar posicion constante para el Return de la pluma
    


    [SerializeField] private GameObject _featherPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        _myCam = Camera.main;
    }


    //Calcula direccion de lanzaminto e instancia la pluma 
    public void FeatherObjective(Vector2 mousePosition)                   // Se calcula la posición donde se lanzará la pluma
    {
        _playerScreenPosition = _myCam.WorldToScreenPoint(gameObject.transform.position);   // Posición del jugador en la pantalla

        _relativeFeatherPosition = mousePosition - _playerScreenPosition;   // Posición del ratón respecto al jugador

        //_featherAngle = FeatherAngle(_relativeFeatherPosition);

        if (GameManager.Instance.FeatherCant > 0)                                                
        {
            GameObject go = Instantiate(_featherPrefab, spawnPoint.position, Quaternion.identity);
            _featherArray[Mathf.Abs(GameManager.Instance.FeatherCant - 3)] = go;
            
            GameManager.Instance.RemoveFeather();
        }
    }

    /*private float FeatherAngle(Vector2 relativeFeatherPosition)
    {
        float x = relativeFeatherPosition.y;    // x = cateto opuesto
        float y = Mathf.Sqrt(Mathf.Pow(relativeFeatherPosition.x, 2) + Mathf.Pow(relativeFeatherPosition.y, 2));    // y = hipotenusa
        float z = x / y;

        float angulo = Mathf.Asin(z);      // Ángulo = Arcoseno (x/y) em radiantes
        angulo *= Mathf.Rad2Deg;           // Pasamos el ángulo de radiantes a grados

        return angulo;
    }*/
}