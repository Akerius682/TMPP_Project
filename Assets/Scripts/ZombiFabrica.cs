using UnityEngine;

public class EnemyFactory
{
    private GameObject _enemyPrefab;

    public EnemyFactory(GameObject enemyPrefab)
    {
        _enemyPrefab = enemyPrefab;
    }

    // Метод для создания врага
    public GameObject CreateEnemy(Vector3 position, Quaternion rotation)
    {
        return GameObject.Instantiate(_enemyPrefab, position, rotation);
    }
}
