using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherWallCol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<FeatherComponent>())
        {
            //collision.gameObject.GetComponent<FeatherPlatformComp>().SetFeatherToWall(this.transform.position);
            collision.GetComponent<FeatherStates>().ChangeState(FeatherStates.FeatherState.PLATFORM);
            Debug.Log("xD");
        }
    }
}
