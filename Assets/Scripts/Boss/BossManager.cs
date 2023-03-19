using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class BossManager : MonoBehaviour
{
    [Header ("Teleport")]
    [SerializeField] private int _teleportCounter;      // Quitar SerializeField
    [SerializeField] private int _teleportsDesired;

    [Header("Enemies")]
    [SerializeField] private int _enemiesCounter;       // Quitar SerializedField
    [SerializeField] private int _enemiesDesired;

    [Header("Trunk")]
    [SerializeField] private int _trunkCounter;         // Quitar Serialized Field
    [SerializeField] private int _trunkDesired;

    [Header("Hits Received")]
    [SerializeField] private float _maxHitsReceivedForTeleport;
    [SerializeField] private float _maxHitsReceivedForEnemy;
    [SerializeField] private float _maxHitsReceivedForTrunk;
    [SerializeField] private float _auxHitsReceived;


    [SerializeField] private float _currentHitsReceived;       //Quitar SerializeField

    private Animator _myAnimator;

    #region Methods
    private void ReceiveDamage(int damageReceived)
    {
        _currentHitsReceived += damageReceived;
    }
    private void CheckAction()      // Cada vez que recibamos daño, verá que acción deberá hacer el boss
    {
        //if (_currentHitsReceived == _maxHitsReceivedForTeleport && _teleportCounter < _teleportsDesired)
        //{
        //    _teleportCounter++;
        //    _myAnimator.SetTrigger("Teleport");
        //    if (_teleportCounter != _teleportsDesired)
        //    {
        //        _currentHitsReceived = 0;
        //    }
        //}                     //TODO LO QUE HAY EN EL UPDATE HABRÄ Q PONERLO AQUI
    }

    public void BossDeath()
    {
        Destroy(gameObject);
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
        if (_currentHitsReceived == _maxHitsReceivedForTeleport && _teleportCounter < _teleportsDesired)          // Quitar de update, está para probar
        {
            _teleportCounter++;
            _myAnimator.SetTrigger("Teleport");
            if (_teleportCounter != _teleportsDesired)
            {
                _currentHitsReceived = 0;
            }
            else
            {
                _auxHitsReceived = _currentHitsReceived;
                _myAnimator.SetBool("isPhase1", false);
                _myAnimator.SetBool("isPhase2", true);
            }
        }

        if (_currentHitsReceived == _maxHitsReceivedForEnemy && _enemiesCounter < _enemiesDesired)              // Qujitar de update
        {
            _enemiesCounter++;
            _myAnimator.SetTrigger("Throw Enemy");
            if (_enemiesCounter != _enemiesDesired)
            {
                _currentHitsReceived = _auxHitsReceived;
            }
            else
            {
                _auxHitsReceived = _currentHitsReceived;
                _myAnimator.SetBool("isPhase2", false);
                _myAnimator.SetBool("isPhase3", true);
            }
        }

        if (_currentHitsReceived == _maxHitsReceivedForTrunk && _trunkCounter < _trunkDesired)              // Qujitar de update
        {
            _trunkCounter++;
            _myAnimator.SetTrigger("Throw Trunk");
            if (_trunkCounter != _trunkDesired)
            {
                _currentHitsReceived = _auxHitsReceived;
            }
            else
            {
                _auxHitsReceived = _currentHitsReceived;
                _myAnimator.SetBool("isPhase3", false);
                _myAnimator.SetBool("isDead", true);
            }
        }
    }
}
