using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRay : MonoBehaviour
{
    [SerializeField]
    private float _range;
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private float _rayTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShootRay()
    {
        
        RaycastHit2D _raycastHit2D = Physics2D.Raycast(transform.position, transform.right, _range);
        if (_raycastHit2D)
        {
            if (_raycastHit2D.transform.GetComponent<InputComponent>())
            {
                StartCoroutine(LineGenerator(_raycastHit2D.point));
            }
        }
        else
        {
            Vector3 NoPoint = new Vector3(_range, 0, 0) * transform.right.x + transform.position;
            StartCoroutine(LineGenerator(NoPoint));
        }
    }
    private IEnumerator LineGenerator(Vector3 target)
    {
        Debug.Log("rayo");
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, target);
        _lineRenderer.startColor= Color.red;
        yield return new WaitForSeconds(_rayTime);
        _lineRenderer.enabled = false;
        _lineRenderer.endColor= Color.red;
    }
}
