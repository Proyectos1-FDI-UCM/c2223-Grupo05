using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherDetectionComponent : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<FeatherComponent>())
        {
            if(!collision.GetComponent<FeatherComponent>().CanReturn)
            {
                collision.GetComponent<FeatherComponent>().ActivateReturn();
            }
        }
            
    }
}
