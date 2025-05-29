using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float Period;
    public GameObject Enemy;

    private float _timeUntilNextSpawn;
    private EnemyFactory enemyFactory;   

    void Start()
    {
        _timeUntilNextSpawn = UnityEngine.Random.Range(0, Period);
        enemyFactory = new EnemyFactory(Enemy); 
    }

    void Update()
    {
        _timeUntilNextSpawn -= Time.deltaTime;
        if (_timeUntilNextSpawn <= 0.0f)
        {
            _timeUntilNextSpawn = Period;
            enemyFactory.CreateEnemy(transform.position, transform.rotation); 
        }
    }
}
