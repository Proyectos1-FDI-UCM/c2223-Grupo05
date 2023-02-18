using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherThrowComponent : MonoBehaviour
{
    private Vector2 _relativeFeatherPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FeatherThrow(Vector2 mousePosition)
    {
        _relativeFeatherPosition = mousePosition - (Vector2)transform.position;

        Debug.Log("Posición relativa del ratón:" + _relativeFeatherPosition);
    }
}
