using System.Collections;
using UnityEngine;


public class RecoilComponent : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    [SerializeField] private float _recForce;
    [SerializeField] private float _delay;
    
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    public void KnockBack(GameObject sender)
    {
        StopAllCoroutines();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        
        _rb2D.AddForce(direction * _recForce, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }


    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(_delay);
        _rb2D.velocity = Vector3.zero;
    }
}
