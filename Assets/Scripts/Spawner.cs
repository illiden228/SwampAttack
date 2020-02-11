using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Wave> Waves;
    public Player Player;

    private Wave _currentWave;
    private int _waveCount;
    private float _lastSpawnTime;
    private int _spawned;

    // Start is called before the first frame update
    void Start()
    {
        SetWave(_waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _lastSpawnTime += Time.deltaTime;
        if(_lastSpawnTime >= _currentWave.EnemyBetweenDelay)
        {
            var enemy = Instantiate(_currentWave.EnemyPrefab, transform.position, transform.rotation, transform);
            enemy.GetComponent<Enemy>().SetTarget(Player);
            _spawned++;
            _lastSpawnTime = 0;
        }
        
        if(_currentWave.EnemyCount <= _spawned)
        {
            if(Waves.Count > _waveCount)
            {
                SetWave(++_waveCount);
                _spawned = 0;
            }
            else
            {
                _currentWave = null;
            }
        }
        Debug.Log("CurrentWave: " + _currentWave + ", WaveCount: " + _waveCount + ", Spawned: " + _spawned + ", EnemyCount: " + _currentWave.EnemyCount);
        Debug.Log("-----------------------");
    }

    public void SetWave(int index)
    {
        _currentWave = Waves[index];
    }
}

[System.Serializable]
public class Wave
{
    public GameObject EnemyPrefab;
    public float EnemyBetweenDelay;
    public int EnemyCount;
}
