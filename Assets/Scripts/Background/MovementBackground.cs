using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBackground : MonoBehaviour
{
    [SerializeField] private Vector2 _velocity;

    private Vector2 _offset;

    private Material _material;

    [SerializeField] private Rigidbody2D _rbplayer;

    // Start is called before the first frame update
    void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        _offset = (_rbplayer.velocity.x * 0.1f) * _velocity * Time.deltaTime; //Mirar la frenada m�s adelante
        _material.mainTextureOffset += _offset;
    }
}
