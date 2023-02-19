using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherThrowComponent : MonoBehaviour
{
    private Vector2 _relativeFeatherPosition;
    private Camera _myCam;
    private Vector2 _playerScreenPosition;
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

        //FeatherObjective(_relativeFeatherPosition);

    }

    private void FeatherAngle(Vector2 relativeFeatherPosition)
    {
        float x = relativeFeatherPosition.y;    // x = cateto opuesto
        float y = Mathf.Sqrt(Mathf.Pow(relativeFeatherPosition.x, 2) + Mathf.Pow(relativeFeatherPosition.y, 2));    // y = hipotenusa
        float z = x / y;

        float _angulo = Mathf.Asin(z);      // �ngulo = Arcoseno (x/y)
        Debug.Log("�ngulo respecto al jugador: " + _angulo);
    }
}