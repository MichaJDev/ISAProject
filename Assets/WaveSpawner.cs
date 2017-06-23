using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;


    }

    public Wave[] waves;
    int nextWave = 0;
    public float timeBetweenWaves = 15f;
    public float waveCountDown;

    float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountDown = timeBetweenWaves;

    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!enemyAlive())
            {
                WaveComplete();
                return;
            }
            else
            {
                return;
            }
        }
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }
    void WaveComplete()
    {
        print("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            print("Completed All Waves, Looping");

        }
        else { nextWave++; }


    }

    bool enemyAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null) { return false; }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        print("Spawning Wave " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(2f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }
    //Spawns Enemies Instantiating them on the GameObjects Position.
    void SpawnEnemy(Transform _enemy)
    {
        print("Spawning Enemy " + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
    }


}
