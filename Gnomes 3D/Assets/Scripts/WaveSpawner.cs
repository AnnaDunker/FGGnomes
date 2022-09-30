using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {Spawning, Waiting, Counting}
   
    [System.Serializable]

  public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 10f;
    public float waveCountdown;

    //Check if enemy is alive
    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;

   void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        
        // If you want spawning to start only after the first wave is killed off. 
        if (state == SpawnState.Waiting)
        {
            // Check if enemy is still alive
            if (!EnemyIsAlive())
            {
                // Begin a new round of waves
                Debug.Log("Wave Compleated!");

            }

            else
            {
                return;
            }
        }
        

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                // start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }

        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("All waves complete! looping...");
        }

        else
        {
            nextWave++;
        }
        
    }

    //Check if enemy is alive
    
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                return false;
            }
        }
                
        return true;
    }
    

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name); 
        state = SpawnState.Spawning;
        
        for (int i = 0; i <_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        // Spawn enemy
        Debug.Log("Spawning Enemy" + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
        
    }

}
