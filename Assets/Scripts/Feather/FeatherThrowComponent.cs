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
    [SerializeField] GameObject _featherPrefab;
    [SerializeField] Transform _spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        _myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FeatherObjective(Vector2 mousePosition)                   // Se calcula la posici�n donde se lanzar� la pluma
    {
        _playerScreenPosition = _myCam.WorldToScreenPoint(gameObject.transform.position);   // Posici�n del jugador en la pantalla

        _relativeFeatherPosition = mousePosition - _playerScreenPosition;   // Posici�n del rat�n respecto al jugador

        Debug.Log("Posici�n relativa del rat�n:" + _relativeFeatherPosition);

        _featherAngle = FeatherAngle(_relativeFeatherPosition);

        Instantiate(_featherPrefab, _spawnPoint.position, Quaternion.identity);
    }

    private float FeatherAngle(Vector2 relativeFeatherPosition)
    {
        float x = relativeFeatherPosition.y;    // x = cateto opuesto
        float y = Mathf.Sqrt(Mathf.Pow(relativeFeatherPosition.x, 2) + Mathf.Pow(relativeFeatherPosition.y, 2));    // y = hipotenusa
        float z = x / y;

        float angulo = Mathf.Asin(z);      // �ngulo = Arcoseno (x/y) em radiantes
        angulo *= Mathf.Rad2Deg;           // Pasamos el �ngulo de radiantes a grados
        Debug.Log("�ngulo respecto al jugador: " + angulo);

        return angulo;
    }
}