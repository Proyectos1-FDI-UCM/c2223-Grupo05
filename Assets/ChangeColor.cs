using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Light2D _light;
 
    // Start is called before the first frame update
    public void ChangeColors(Color color)
    {
        Debug.Log("ME CAGO EN DIOS");
        _light.color = color; 
    }
}
