using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointComponent : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            GameManager.Instance.Checkpoint();
            
        }
    }
}