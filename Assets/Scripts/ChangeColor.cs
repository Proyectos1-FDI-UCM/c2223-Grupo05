using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    
    // Start is called before the first frame update
    private void Start() //Player inicia el juego con el color asignado
    {
        _light.color = SkinManager.Instance.Col;
    }
    public void ChangeColors(Color color) //metodo de muestra en img player
    {
        _light.color = color; 
    }
}
