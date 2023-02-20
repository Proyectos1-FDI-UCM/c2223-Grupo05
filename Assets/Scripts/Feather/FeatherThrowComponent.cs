using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherThrowComponent : MonoBehaviour
{
    private Vector3 _relativeFeatherPosition;
    private Camera _myCam;
    private Vector2 _playerScreenPosition;

    [SerializeField] private GameObject _featherPrefab;
    [SerializeField] private Transform _spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        _myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FeatherObjective(Vector2 mousePosition)                   // Se calcula la posición donde se lanzará la pluma
    {
        _playerScreenPosition = _myCam.WorldToScreenPoint(gameObject.transform.position);   // Posición del jugador en la pantalla

        _relativeFeatherPosition =  (Vector3)(mousePosition - _playerScreenPosition);   // Posición del ratón respecto al jugador

        Quaternion rotation = FeatherAngle(_relativeFeatherPosition);

        Debug.Log("Posición relativa del ratón:" + _relativeFeatherPosition);

        rotation.x += 90;

        Instantiate(_featherPrefab, _spawnPoint.position, rotation);
        
    }

    private Quaternion FeatherAngle(Vector3 relativeFeatherPosition)
    {
        Quaternion rotation = Quaternion.LookRotation(relativeFeatherPosition, Vector3.left);
        return rotation;

        //float x = relativeFeatherPosition.y;    // x = cateto opuesto
        //float y = Mathf.Sqrt(Mathf.Pow(relativeFeatherPosition.x, 2) + Mathf.Pow(relativeFeatherPosition.y, 2));    // y = hipotenusa
        //float z = x / y;

        //float angulo = Mathf.Asin(z);      // Ángulo = Arcoseno (x/y) en radiantes
        //angulo = angulo * Mathf.Rad2Deg;  // Conversión de Ángulo de radiantes a grados
        //Debug.Log("Ángulo respecto al jugador: " + angulo);
        //return angulo;
        
    }
}