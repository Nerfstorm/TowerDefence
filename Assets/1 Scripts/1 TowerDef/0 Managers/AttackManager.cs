using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    public GameObject winMenuUI;
    public GameObject inGameUI;
    public GameObject Enemy;

    int spawncount;
    public float spawnrate;
    float spawndelay;

    void Start() {

        spawncount = LevelData.EnemyCount;
        spawndelay = LevelData.EnemySpawnDelay;

        InvokeRepeating(nameof(SpawnEnemy), spawndelay, spawnrate);
        InvokeRepeating("CheckWin", spawndelay + spawnrate * spawncount, 0.5f);
    }
    void SpawnEnemy() {
        var position = new Vector2(Random.Range(-475f, 475f), Random.Range(1020, 1200));
        Instantiate(Enemy, position, Quaternion.identity);
        if (--spawncount == 0) CancelInvoke("SpawnEnemy");
    }
    
    void CheckWin() {
        if (!GameObject.FindGameObjectWithTag("Enemy")) {
                winMenuUI.SetActive(true);
                Time.timeScale = 0f;
                inGameUI.SetActive(false);
            }
        }
    }
