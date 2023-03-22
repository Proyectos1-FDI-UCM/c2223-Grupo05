using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorialImages : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())
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
