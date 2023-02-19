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

    public void FeatherObjective(Vector2 mousePosition)                   // Se calcula la posición donde se lanzará la pluma
    {
        _playerScreenPosition = _myCam.WorldToScreenPoint(gameObject.transform.position);   // Posición del jugador en la pantalla

        _relativeFeatherPosition = mousePosition - _playerScreenPosition;   // Posición del ratón respecto al jugador

        Debug.Log("Posición relativa del ratón:" + _relativeFeatherPosition);
    }
}
