using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkDetectionComponent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _myRigidbody2D;
    [SerializeField] private WoodComponent _woodCoponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.GetComponent<InputComponent>())
        {
            Debug.Log("CaeTronco");

            _myRigidbody2D.gravityScale = 1;
            _woodCoponent.Falling = true;
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
