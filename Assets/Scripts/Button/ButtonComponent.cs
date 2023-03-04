using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonComponent : MonoBehaviour
{
    [SerializeField] private PlatformComponent _myPlatformComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<FeatherComponent>() && collision.gameObject.GetComponentInParent<FeatherStates>().CurrrentState == FeatherStates.FeatherState.FEATHER)
        {
            _myPlatformComponent.ChangeMove();
            

            collision.gameObject.GetComponentInParent<FeatherStates>().FreezeAutoReturn();
            collision.gameObject.GetComponentInParent<FeatherStates>().ChangeState(FeatherStates.FeatherState.PLATFORM);
        }
    }
}
