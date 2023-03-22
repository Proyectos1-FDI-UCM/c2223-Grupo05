using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorialImages3 : MonoBehaviour
{
    private bool _canDestroy = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>() && GameManager.Instance._sword)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            _canDestroy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>() && _canDestroy)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
