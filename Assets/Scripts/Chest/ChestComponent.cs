using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static FeatherStates;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ChestComponent : MonoBehaviour
{
    private bool _canInteract;
    [SerializeField] private GameObject _content;
    [SerializeField] private float _objectOffset;
    private float _countdown = 0;
    [SerializeField] private float _limit;
    private bool _opened = false;


    private Animator _myAnimator;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())         // Cuando el jugador está en el área del cofre
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
            
            if (Input.GetButtonDown("Interact"))     // Habría que ver como recibir el input de forma externa
            {
                _opened = true;

                gameObject.GetComponentInChildren<Light2D>().intensity = 0; /*Mathf.Lerp(gameObject.GetComponentInChildren<Light2D>().intensity, 0, 0.1f * Time.time);*/

                _myAnimator.SetBool("Opened", _opened);

                //_countdown += Time.deltaTime;

                //if (_countdown > _limit)
                //{

                Instantiate(_content, new Vector2(transform.position.x, transform.position.y + _objectOffset), Quaternion.identity);

                this.enabled = false;

                //}
                //_canInteract = false;
            }
        }
    }

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
    }
}
