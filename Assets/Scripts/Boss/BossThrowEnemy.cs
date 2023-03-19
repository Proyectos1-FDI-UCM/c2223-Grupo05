using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThrowEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _myEnemyPrefab;
    [SerializeField] Transform _enemySpawnPoint;
    // Start is called before the first frame update
    public void SpawnEnemy()
    {
        Instantiate(_myEnemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
