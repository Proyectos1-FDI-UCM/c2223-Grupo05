using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static FeatherStates;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ChestComponent : MonoBehaviour
{
    private bool _canInteract;
    [SerializeField] private GameObject _content;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())         // Cuando el jugador est� en el �rea del cofre
        {
            _canInteract = true;                                    // Puede interactuar
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())
        {
            _canInteract = false;
        }
    }

    private void Update()
    {
        if (_canInteract)
        {
            if (Input.GetButtonDown("Interact"))                    // Habr�a que ver como recibir el input de forma externa
            {
                gameObject.GetComponentInChildren<Light2D>().intensity = 0;
                //A�adir acciones correspondientes a cuando se abre el cofre
            }
        }
    }
}
