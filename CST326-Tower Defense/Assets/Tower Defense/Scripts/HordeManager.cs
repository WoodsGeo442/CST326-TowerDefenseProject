using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class HordeManager : MonoBehaviour
{

  public Wave enemyWave;
  public PlaceTower9001 towerS;
  public HordeManager hordeS;
  public GameController gameS;
  public Path enemyPath;
  public int enemyCount = 0;

  public AudioSource audioSource;

  public AudioClip deathSound;

  public float volume = 0.5f;


    IEnumerator Start()
  {

    Debug.Log("before spawn small");
    StartCoroutine("SpawnSmallEnemies");
    StartCoroutine("SpawnBigEnemies");

    yield break;

  }

    public void Update()
    {
        if (enemyCount == 0)
        {
            gameS.GetComponent<GameController>().ShowRestart();
        }
    }

    //pick our enemy to spawn
    //spawn it
    //wait
    IEnumerator SpawnSmallEnemies()
  {
    for (int i = 0; i < enemyWave.groupsOfEnemiesInWave.Length; i++)
    {

      for (int j = 0; j < enemyWave.groupsOfEnemiesInWave[i].numberOfSmall; j++)
      {
        Enemy spawnedEnemy = Instantiate(enemyWave.groupsOfEnemiesInWave[i].smallMichaelEnemy).GetComponent<Enemy>();
        spawnedEnemy.route = enemyPath;
        spawnedEnemy.towerScript = towerS;
        spawnedEnemy.hordeScript = hordeS;
        spawnedEnemy.gameScript = gameS;
        enemyCount++;
        yield return new WaitForSeconds(enemyWave.groupsOfEnemiesInWave[i].coolDownBetweenSmallEnemies);

      }

      yield return new WaitForSeconds(enemyWave.coolDownBetweenSmallWave); // cooldown between groups
    }

    Debug.Log("done with small");

  }

  IEnumerator SpawnBigEnemies()
  {
    Debug.Log("big bad");
    for (int i = 0; i < enemyWave.groupsOfEnemiesInWave.Length; i++)
    {

        for (int j = 0; j < enemyWave.groupsOfEnemiesInWave[i].numberOfLarge; j++)
        {
            Enemy spawnedEnemy = Instantiate(enemyWave.groupsOfEnemiesInWave[i].bigAwesomeSuperBadGuyClayEnemy).GetComponent<Enemy>();
            spawnedEnemy.route = enemyPath;
            spawnedEnemy.towerScript = towerS;
            spawnedEnemy.hordeScript = hordeS;
            spawnedEnemy.gameScript = gameS;
            enemyCount++;
            yield return new WaitForSeconds(enemyWave.groupsOfEnemiesInWave[i].coolDownBetweenLargeEnemies);

        }

    yield return new WaitForSeconds(enemyWave.coolDownBetweenSmallWave); // cooldown between groups
    }
        //yield return null;
  }

  public void RemoveEnemy()
    {

        audioSource.Play();
        enemyCount--;
    }
  
}



[Serializable]
public struct Group
{
  public GameObject smallMichaelEnemy;
  public GameObject bigAwesomeSuperBadGuyClayEnemy;
  public int numberOfSmall;
  public int numberOfLarge;
  public float coolDownBetweenSmallEnemies;
  public float coolDownBetweenLargeEnemies;
}

[Serializable]
public struct Wave
{
  public Group[] groupsOfEnemiesInWave;
  public float coolDownBetweenSmallWave;
  public float coolDownBetweenLargeWave;
}

