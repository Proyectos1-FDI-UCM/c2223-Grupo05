using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonComponent : MonoBehaviour
{
    [SerializeField] private PlatformComponent _myPlatformComponent;

    private bool _buttonActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_buttonActivated && (bool)collision.gameObject.GetComponent<FeatherComponent>() && collision.gameObject.GetComponentInParent<FeatherStates>().CurrrentState == FeatherStates.FeatherState.FEATHER)
        {
            Debug.Log("Entra en collider");
            _buttonActivated = !_buttonActivated;

            _myPlatformComponent.ChangeMove();

            collision.gameObject.GetComponentInParent<FeatherStates>().FreezeAutoReturn();
            collision.gameObject.GetComponentInParent<FeatherStates>().ChangeState(FeatherStates.FeatherState.PLATFORM);
        }
    }

    //private void Update()
    //{
    //    if (_buttonActivated && _myPlatformComponent.MoveTowardsTarget == false && _myPlatformComponent.gameObject.transform.position == _myPlatformComponent.TargetPosition.position)
    //    {
    //        _myPlatformComponent.ChangeMove();
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("La pluma pasa");
        // Condicion antigua if: (bool)collision.gameObject.GetComponent<PlatformFeatherComponent>() && collision.gameObject.GetComponentInParent<FeatherStates>().CurrrentState == FeatherStates.FeatherState.PLATFORM
        // Dentro del anterior if: collision.gameObject.GetComponentInParent<FeatherStates>().ChangeState(FeatherStates.FeatherState.RETURN);
        if (_buttonActivated && collision.gameObject.GetComponentInParent<FeatherStates>().CurrrentState == FeatherStates.FeatherState.PLATFORM)
        {
            Debug.Log("Se sale la pluma");
            _buttonActivated = !_buttonActivated;
            _myPlatformComponent.ChangeMove();

        }
    }

}
