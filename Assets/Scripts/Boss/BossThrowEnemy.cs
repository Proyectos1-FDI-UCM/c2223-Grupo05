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
        SoundComponent.Instance.PlaySound(SoundComponent.Instance._bossEneymThrow);
        GameObject go = Instantiate(_myEnemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
        go.GetComponentInChildren<ThownEnemyComponent>().SetSpin(this.transform.localScale.x);
    }
    
}
