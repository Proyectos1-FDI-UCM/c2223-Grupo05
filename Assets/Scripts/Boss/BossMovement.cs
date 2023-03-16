using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private BossManager _myBossManager;
    private Rigidbody2D _myrigidbody2D;

    [SerializeField] private float _movingTime;


    #region Methods
    private IEnumerator SimpleMovement()
    {
        
        yield return new WaitForSeconds(_movingTime);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myrigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
