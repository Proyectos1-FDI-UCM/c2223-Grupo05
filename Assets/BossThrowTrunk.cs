using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThrowTrunk : MonoBehaviour
{
    [SerializeField] private GameObject _myTrunkPrefab;
    [SerializeField] Transform _trunkSpawnPoint;
    // Start is called before the first frame update
    public void SpawnTrunk()
    {
        Instantiate(_myTrunkPrefab, _trunkSpawnPoint.position, Quaternion.identity);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
