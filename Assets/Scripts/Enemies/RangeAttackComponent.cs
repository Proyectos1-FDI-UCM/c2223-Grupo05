using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RangeAttackComponent : MonoBehaviour
{
    private SpinComponent _spinComponent;
    private void Start()
    {
        _spinComponent = GetComponent<SpinComponent>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            Debug.Log("Entro");
            _spinComponent.StartCoroutine(_spinComponent.Spin());
        }
    }
    

}
