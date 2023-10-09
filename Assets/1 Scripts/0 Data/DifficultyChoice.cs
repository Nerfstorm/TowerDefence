using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyChoice : MonoBehaviour {

    public int EasyWallHp;

    public int EasyStartcoin;
    public int EasyPerSecondcoin;

    public int EasyEnemySpeed;
    public int EasyHealthMax;

    public int EasyEnemyCount;
    public int EasyEnemySpawnDelay;


    public int MediumWallHp;

    public int MediumStartcoin;
    public int MediumPerSecondcoin;

    public int MediumEnemySpeed;
    public int MediumHealthMax;

    public int MediumEnemyCount;
    public int MediumEnemySpawnDelay;


    public int HardWallHp;

    public int HardStartcoin;
    public int HardPerSecondcoin;

    public int HardEnemySpeed;
    public int HardHealthMax;

    public int HardEnemyCount;
    public int HardEnemySpawnDelay;



    public int ImpsWallHp;

    public int ImpsStartcoin;
    public int ImpsPerSecondcoin;

    public int ImpsEnemySpeed;
    public int ImpsHealthMax;

    public int ImpsEnemyCount;
    public int ImpsEnemySpawnDelay;

    public void EasyDiff() {

        LevelData.WallHp = EasyWallHp;
        LevelData.Startcoin = EasyStartcoin;
        LevelData.PerSecondcoin = EasyPerSecondcoin;
        LevelData.EnemySpeed = EasyEnemySpeed;
        LevelData.EnemyHealthMax = EasyHealthMax;
        LevelData.EnemyCount = EasyEnemyCount;
        LevelData.EnemySpawnDelay = EasyEnemySpawnDelay;

    }
    public void MediumDiff() {
        LevelData.WallHp = MediumWallHp;
        LevelData.Startcoin = MediumStartcoin;
        LevelData.PerSecondcoin = MediumPerSecondcoin;
        LevelData.EnemySpeed = MediumEnemySpeed;
        LevelData.EnemyHealthMax = MediumHealthMax;
        LevelData.EnemyCount = MediumEnemyCount;
        LevelData.EnemySpawnDelay = MediumEnemySpawnDelay;
    }

    public void HardDiff() {
        LevelData.WallHp = HardWallHp;
        LevelData.Startcoin = HardStartcoin;
        LevelData.PerSecondcoin = HardPerSecondcoin;
        LevelData.EnemySpeed = HardEnemySpeed;
        LevelData.EnemyHealthMax = HardHealthMax;
        LevelData.EnemyCount = HardEnemyCount;
        LevelData.EnemySpawnDelay = HardEnemySpawnDelay;
    }

    public void ImpsDiff() {
        LevelData.WallHp = ImpsWallHp;
        LevelData.Startcoin = ImpsStartcoin;
        LevelData.PerSecondcoin = ImpsPerSecondcoin;
        LevelData.EnemySpeed = ImpsEnemySpeed;
        LevelData.EnemyHealthMax = ImpsHealthMax;
        LevelData.EnemyCount = ImpsEnemyCount;
        LevelData.EnemySpawnDelay = ImpsEnemySpawnDelay;
    }


}
