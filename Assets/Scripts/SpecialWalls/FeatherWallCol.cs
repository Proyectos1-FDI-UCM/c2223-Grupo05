using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherWallCol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<FeatherComponent>())
        {
            collision.GetComponentInParent<FeatherStates>().ChangeState(FeatherStates.FeatherState.PLATFORM);
        }
    }
}
