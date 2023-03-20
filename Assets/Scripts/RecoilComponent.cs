using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RecoilComponent : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _recForceX;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    public void Recoil(float direction)
    {
        Vector3 aux = new Vector3(direction, 0, 0).normalized; //direction into 1 / -1
        _rb.AddForce(new Vector3( _recForceX * aux.x,0, 0), ForceMode2D.Impulse);

        


    }
}
