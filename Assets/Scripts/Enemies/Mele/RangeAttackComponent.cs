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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            Debug.Log("Entro");
            if (_spinComponent.CanSpin)
            {
                _spinComponent.StartCoroutine(_spinComponent.Spin());
            }
            
        }
    }
    

}
