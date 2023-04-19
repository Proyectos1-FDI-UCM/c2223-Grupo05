using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iFramesComponent : MonoBehaviour
{
    [SerializeField] private float _time; //tiempo para que pueda volver a recibir daño
    [SerializeField] private int _flashes;

    private SpriteRenderer _mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IFrames()
    {
        if ((bool)GetComponent<BossManager>())
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            StartCoroutine(IFrameProcess());
        }
        else
        {
            StartCoroutine(IFrameProcess());            
        }
    }
    private IEnumerator IFrameProcess()
    {
        for (int i = 0; i < _flashes; i++)
        {
            //_mySpriteRenderer.color = new Color(1, 0, 0, 0.75f);
            //yield return new WaitForSeconds(_time);
            //_mySpriteRenderer.color = Color.white;
            GetComponent<ShowDamage>().StartCoroutine(GetComponent<ShowDamage>().ModSprite());
            yield return new WaitForSeconds(_time);
            if ((bool)GetComponent<BossManager>())
            {
                GetComponent<PolygonCollider2D>().enabled = true;
            }
            else
            {
                GameManager.Instance.CanTakeDamage = true;
            }
        }
    }
}
