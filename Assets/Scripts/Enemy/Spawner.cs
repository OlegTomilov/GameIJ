using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;
    private float _minDistantionX = 50;
    private float _maxDistantionX = 450;

    private void Awake()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out Enemy enemy))
            {
                _elapsedTime = 0;

                float spawnPosition = Random.Range(_minDistantionX, _maxDistantionX);
                Vector3 spawnPoint = new Vector3(spawnPosition, transform.position.y, transform.position.z);

                SetEnemy(enemy, spawnPoint);
            }
        }
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        
        enemy.transform.position = spawnPoint;
    }

}
