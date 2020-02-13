using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Wave> Waves;
    public Player Player;
    public Action<int, int> ChangeEnemyCount;
    public GameObject NextWaveButton;

    private Wave _currentWave;
    private int _waveCount;
    private float _lastSpawnTime;
    private int _spawned;

    void Start()
    {
        SetWave(_waveCount);
    }

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
            ChangeEnemyCount?.Invoke(_spawned, _currentWave.EnemyCount);
            _lastSpawnTime = 0;
        }
        
        if(_currentWave.EnemyCount <= _spawned)
        {
            if(Waves.Count > _waveCount + 1)
            {
                NextWaveButton.SetActive(true);
                _currentWave = null;
            }
            else
            {
                _currentWave = null;
            }
        }
    }

    public void NextWave()
    {
        SetWave(++_waveCount);
        _spawned = 0;
        ChangeEnemyCount?.Invoke(0, 1);
        NextWaveButton.SetActive(false);
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
