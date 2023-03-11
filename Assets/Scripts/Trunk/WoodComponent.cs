using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())
        {
            Debug.Log("Jugador la palma");

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
