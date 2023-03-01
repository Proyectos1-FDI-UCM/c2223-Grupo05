using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class FeatherReturn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if((bool)collision.gameObject.GetComponent<FeatherComponent>())
        {
            if (collision.GetComponent<FeatherComponent>().CanReturn)
            {

                GameManager.Instance.AddFeather();
                Object.Destroy(collision.gameObject);
            }
            
        }
    }
}
