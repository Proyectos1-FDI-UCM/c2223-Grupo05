using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static FeatherStates;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ChestComponent : MonoBehaviour
{
    private bool _interaction;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())
        {
            _interaction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())
        {
            gameObject.GetComponentInChildren<Light2D>().intensity = 1;
            _interaction = false;
        }
    }

    private void Update()
    {
        if (_interaction)
        {
            if (Input.GetButtonDown("Interact"))
            {
                gameObject.GetComponentInChildren<Light2D>().intensity = 5;
            }
        }
    }
}
