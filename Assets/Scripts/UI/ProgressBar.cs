using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Spawner Spawner;

    private Slider _slider;

    void Start()
    {
        Spawner.ChangeEnemyCount += ChangeEnemyCount;
        _slider = GetComponentInChildren<Slider>();
        _slider.value = 0;
    }

    private void ChangeEnemyCount(int spawned, int enemyCount)
    {
        _slider.value = (float)spawned / enemyCount;
    }

    private void OnDestroy()
    {
        Spawner.ChangeEnemyCount -= ChangeEnemyCount;       
    }
}
