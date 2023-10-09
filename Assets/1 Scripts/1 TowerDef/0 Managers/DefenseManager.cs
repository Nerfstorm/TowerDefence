using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseManager : MonoBehaviour {

    public GameObject deathMenuUI;
    public GameObject inGameUI;

    public Slider hpbar;
    int Maxhp;

 
    void Start() {
        Maxhp = LevelData.WallHp;

        hpbar.maxValue = Maxhp; hpbar.value = Maxhp;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        GameObject other = collider.gameObject;
        hpbar.value -= 10;
        Destroy(other);
        if (hpbar.value == 0) Lose();
    }

    public void Lose() {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        inGameUI.SetActive(false);
    }

}
