using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleport : MonoBehaviour
{
    [SerializeField] private Transform _teleportPoint;

    public void TeleportToPoint()
    {
        Debug.Log("Nos teletransportamos");
        transform.position = _teleportPoint.position;
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
