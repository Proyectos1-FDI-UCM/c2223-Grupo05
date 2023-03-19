using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class BossManager : MonoBehaviour
{
    [SerializeField] private int _teleportCounter;
    [SerializeField] private int _teleportsDesired;

    [SerializeField] private float _CurrentHitsReceived;       //Quitar SerializeField
    [SerializeField] private float _maxHitsReceivedForTeleport;

    private Animator _myAnimator;

    #region Methods
    private void ReceiveDamage(int damageReceived)
    {
        _CurrentHitsReceived += damageReceived;
    }
    private void CheckAction()      // Cada vez que recibamos daño, verá que acción deberá hacer el boss
    {
        if (_CurrentHitsReceived == _maxHitsReceivedForTeleport && _teleportCounter < _teleportsDesired)
        {
            _teleportCounter++;
            _myAnimator.SetTrigger("Teleport");
            if (_teleportCounter != _teleportsDesired)
            {
                _CurrentHitsReceived = 0;
            }
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
        if (_CurrentHitsReceived == _maxHitsReceivedForTeleport && _teleportCounter <T _teleportsDesired)          // Quitar de update, está para probar
        {
            _teleportCounter++;
            _myAnimator.SetTrigger("Teleport");
            if (_teleportCounter != _teleportsDesired)
            {
                _CurrentHitsReceived = 0;
            }
        }
    }
}
