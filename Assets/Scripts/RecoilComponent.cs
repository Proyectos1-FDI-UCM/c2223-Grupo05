using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RecoilComponent : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _recForceY;
    [SerializeField] private float _recForceX;
    [SerializeField] private float _timeBetween;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    public IEnumerator Recoil(float direction)
    {
        
        Vector3 aux = new Vector3(direction, 0, 0).normalized; //direction into 1 / -1
        Vector3 force1= new Vector3(direction, _recForceY, 0f);
        _rb.AddForce(force1, ForceMode2D.Impulse);

        yield return new WaitForSeconds(_timeBetween);

        Vector3 force2 = new Vector3(direction * _recForceX, 0, 0);
        _rb.AddForce(force2, ForceMode2D.Impulse);
        
       

        


    }
}
