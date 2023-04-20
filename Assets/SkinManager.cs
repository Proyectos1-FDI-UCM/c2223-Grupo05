using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SkinManager : MonoBehaviour
{
   [SerializeField] private GameObject _player;
    private SpriteRenderer _renderer;
    [SerializeField] private Color[] _colorSelector;
    //private Color _color;
    private int _cIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        _renderer = _player.GetComponent<SpriteRenderer>();
        
        ChangeSkin(_colorSelector[_cIndex]);
    }
    public void ChangeSkin(Color color)
    { 
        //NECESARIO PODER ACCEDER AL LIGHT DEL PLAYER PARA PODER MODIFICARLO, NO SE COMO HACERLO
        _player.GetComponent<ChangeColor>().ChangeColors(color);
        _renderer.color = color;
        
    }
    public void AvanzaColor()
    {
        if (_cIndex == _colorSelector.Length - 1)
        {
            _cIndex = 0;
        }
        else _cIndex++;

        ChangeSkin(_colorSelector[_cIndex]);
    }
    public void RetrocedeColor()
    {
        if (_cIndex == 0)
        {
            _cIndex = _colorSelector.Length - 1;
        }
        else _cIndex--;
        ChangeSkin(_colorSelector[_cIndex]);
    }
}
