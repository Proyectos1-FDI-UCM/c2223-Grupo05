using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebacOLISIONESÇ : MonoBehaviour
{
    [SerializeField] private LayerMask _wallsLayer;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == _wallsLayer)
        {
            Destroy(this.gameObject);
        }
    }
}
