using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private SpriteRenderer _renderer;
    [SerializeField] private Color[] _colorSelector;
    
    private Color _color;
    public Color Col { get { return _color; } } 
    private int _cIndex = 0;
    static private SkinManager _insatance;
    static public SkinManager Instance { get { return _insatance; } }
    private void Awake()
    {
        if(this == null)
        {
            _insatance  = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        _renderer = _player.GetComponent<SpriteRenderer>();
        
        _color = _colorSelector[_cIndex];
    }
    public void ChangeSkin(Color color)
    {
        _player.GetComponentInChildren<Light2D>().color = color;

    }
    public void AvanzaColor()
    {
        if (_cIndex == _colorSelector.Length - 1)
        {
            _cIndex = 0;
        }
        else _cIndex++;

        _color = _colorSelector[_cIndex];
    }
    public void RetrocedeColor()
    {
        if (_cIndex == 0)
        {
            _cIndex = _colorSelector.Length - 1;
        }
        else _cIndex--;
        _color = _colorSelector[_cIndex];
    }
}
