using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class BossManager : MonoBehaviour
{
    [SerializeField] private float _CurrentHitsReceived;       //Quitar SerializeField
    [SerializeField] private float _maxHitsReceived;

    private Animator _myAnimator;

    #region Methods
    private void ReceiveDamage(int damageReceived)
    {
        _CurrentHitsReceived += damageReceived;
    }
    private void CheckAction()      // Cada vez que recibamos daño, verá que acción deberá hacer el boss
    {
        if (_CurrentHitsReceived >= _maxHitsReceived)
        {
            _myAnimator.SetTrigger("Teleport");
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_CurrentHitsReceived >= _maxHitsReceived)          // Quitar de update, está para probar
        {
            _myAnimator.SetTrigger("Teleport");
            _CurrentHitsReceived = 0;
        }
    }
}
