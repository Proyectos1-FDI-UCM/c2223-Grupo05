using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    //Inflinge daño al player
    
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {

            if (this.GetComponent<SpinComponent>().EnableSpinDamage)
            {
                GameManager.Instance.Loselifes();
                GameManager.Instance.Loselifes();
            }
            else
            {
                GameManager.Instance.Loselifes();
            }
            
        }
    }
   

     
    private void Update()
    {
       
    }
}
