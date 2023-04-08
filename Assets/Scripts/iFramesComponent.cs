using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iFramesComponent : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private int _flashes;

    private int _ownLayer;
    [SerializeField] private int _objectiveLayer;

    private SpriteRenderer _mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _ownLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator IFrames()
    {
        Physics2D.IgnoreLayerCollision(_ownLayer, _objectiveLayer, true);

        for (int i = 0; i < _flashes; i++)
        {
            _mySpriteRenderer.color = new Color(1, 0, 0, 0.75f);
            yield return new WaitForSeconds(_time);
            _mySpriteRenderer.color = Color.white;
            yield return new WaitForSeconds(_time);
        }

        Physics2D.IgnoreLayerCollision(_ownLayer, _objectiveLayer, false);
    }
}
