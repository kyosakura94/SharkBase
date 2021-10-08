using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum _SpawnState { SPAWNING, WAITING, COUNTING };

public class Shooting : MonoBehaviour
{
    [System.Serializable] //allows us to change values inside unity inspector
    public class Wave
    {
        public string name; //name of the wave
        public Transform enemy; //select what enemy will spawn in
        public int count; //The amount that will spawn in
        public float rate; //the rate that they spawn in
    }

    public Wave[] waves; //make a waves array
    private int nextWave = 0; //store the index of the wave we will make next
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f; //stores the time between waves
    private float waveCountdown; //countdown to the next wave defaults to 0
    public GameObject houseAlive;
    private float searchCountdown = 1f; //how often we check if an enemy is alive

    private _SpawnState state = _SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves; //sets the wave countdown to be the timeBetweenWaves
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points");
        }
    }

    void Update()
    {
        if (houseAlive)
        {
            if (state == _SpawnState.WAITING)
            {
                if (!EnemyIsAlive()) //if enemy is not alive
                {
                    WaveCompleted(); //calls on the WaveCompleted method
                }
                else //if an enemy is alive
                {
                    return;
                }
            }

            if (waveCountdown <= 0f) //what happens when the countdown is 0
            {
                if (state != _SpawnState.SPAWNING) //what happens if state is not equal to SpawnState.SPAWNING
                {
                    StartCoroutine(SpawnWave(waves[nextWave])); //Starts spawning
                }
            }
            else 
            {
                waveCountdown -= Time.deltaTime; 
            }
        }
        else
            Destroy(gameObject);


    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = _SpawnState.COUNTING; 
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) 
        {
            nextWave = 0; 
            Debug.Log("ALL WAVES COMPLETE!");
        }

        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f) //what happens when searchCountdown equals 0
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null) //Check if any enemies are alive
            {
                return false; //no enemies are alive
            }
        }
        return true; //enemies are alive
    }

    IEnumerator SpawnWave(Wave _wave) //allows us to spawn a wave after time
    {
        Debug.Log("Spawning wave" + _wave.name);
        state = _SpawnState.SPAWNING; //Setting the state to SPAWNING

        for (int i = 0; i < _wave.count; i++) //create a for loop that will make sure we spawn the right amount of enemies 
        {
            SpawnEnemy(_wave.enemy); //spawn the enemy
            yield return new WaitForSeconds(1f / _wave.rate); //wait a set time before running loop again
        }

        state = _SpawnState.WAITING; //Setting the state to WAITING

        yield break;
    }

    void SpawnEnemy(Transform _enemy) //method to spawn selected enemy
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

}
