using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public delegate void SpawnerStarted();
    public event SpawnerStarted onSpawnerStarted;

    float _spawnerPosY;
    [SerializeField] int _spawnableCount;
    [SerializeField] int _minSpawnablesCount;
    [SerializeField] int _maxSpawnablesCount;
    [SerializeField] float _spawnRangeMin;
    [SerializeField] float _spawnRangeMax;
    [SerializeField] float _nextSpawnMin;   
    [SerializeField] SpawnableController _spawnable;
    [SerializeField] SpawnableController[] _spawnedObjs;
    [SerializeField] Transform _ground;
    //[SerializeField] Transform _player;

    WaitForSeconds _spawnCooldown = new WaitForSeconds(1.5f);

    void OnEnable()
    {
        onSpawnerStarted += SetRefs;
        onSpawnerStarted += PrewarmSpawner;
    }

    void OnDisable()
    {
        onSpawnerStarted -= SetRefs;
        onSpawnerStarted -= PrewarmSpawner;
    }

    IEnumerator Start() {
        OnSpawnerStarted();
        int i = 0;
        while (true)
        {
            if(i >= _spawnableCount)
            {
                i = 0;
                yield return _spawnCooldown;
            }
            _spawnedObjs[i++].PushSpawnable(new Vector3(Random.Range(_spawnRangeMin, _spawnRangeMax), _spawnerPosY, 0));
            yield return new WaitForSeconds(Random.Range(_nextSpawnMin, 0.75f + _nextSpawnMin));
        }
    }

    void PrewarmSpawner()
    {
        _spawnableCount = Random.Range(_minSpawnablesCount, _maxSpawnablesCount);
        _spawnedObjs = new SpawnableController[_spawnableCount];
        _spawnerPosY = transform.position.y;
        Vector3 spawnedPos;
        for (int i = 0; i < _spawnableCount; i++)
        {
            spawnedPos = new Vector3(Random.Range(_spawnRangeMin, _spawnRangeMax), _spawnerPosY, 0);
            _spawnedObjs[i] = Instantiate(_spawnable);
            _spawnedObjs[i].SetSpawnablePos(spawnedPos);
        }
    }

    void SetRefs()
    {
        float groundHalfScale = _ground.localScale.x / 2;
        float spawnableHalfScale = _spawnable.transform.localScale.x / 2;
        _spawnRangeMin = -groundHalfScale + spawnableHalfScale;
        _spawnRangeMax = groundHalfScale - spawnableHalfScale;
    }

    void OnSpawnerStarted()
    {
        if (onSpawnerStarted != null)
        {
            onSpawnerStarted();
        }
    }
}
