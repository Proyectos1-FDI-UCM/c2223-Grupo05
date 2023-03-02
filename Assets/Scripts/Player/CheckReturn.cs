using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CheckReturn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if((bool)collision.gameObject.GetComponent<FeatherReturn>())
        {
            GameManager.Instance.AddFeather();
            Object.Destroy(collision.transform.parent.gameObject);
        }
    }
}
