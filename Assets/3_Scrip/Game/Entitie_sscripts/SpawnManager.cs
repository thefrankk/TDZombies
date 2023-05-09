using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] spawnPoint;
    public GameObject[] enemies;
    public int wave;
    public int wavenCount;
    public int enemyBreed;
    public bool spawning;
    private int numbersEnemies;
    private Manager gameManager;
    

    private void Start()
    {
        wavenCount = 2;
        wave = 1;
        spawning = false;
        numbersEnemies = 0;
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();

    }

    private void Update()
    {
        if (spawning == false && numbersEnemies == gameManager.defeatEnemies)
        {
            StartCoroutine(SpawnWave(wavenCount));
        }
    }

    IEnumerator SpawnWave (int waveN)
    {
        spawning = true;

        yield return new WaitForSeconds(4);
        for (int i =0; i<waveN; i ++)
        {
            SpawnWave(wave);

            yield return new WaitForSeconds(2);

        }
        wave += 1;
        wavenCount += 2;
        spawning = false;

        yield break;

        }

    void Spawnenemy(int wave)
    {
        int spawnPos = Random.Range(0, 3);
        if (wave ==1)
        {
            enemyBreed = 1;

        }
        else if (wave <4)
        {
            enemyBreed = Random.Range(0,2);

        }
        else
        {
            enemyBreed = Random.Range(0,3);
        }

        Instantiate(enemies[enemyBreed], spawnPoint[spawnPos].transform.position, spawnPoint[spawnPos].transform.rotation);
        numbersEnemies += 1;
    }
}
