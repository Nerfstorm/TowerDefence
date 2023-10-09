using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallDamage : MonoBehaviour {

    public GameObject deathMenuUI;
    public GameObject inGameUI;
    public Slider slider;

    private void OnTriggerEnter2D(Collider2D collider) {
        GameObject other = collider.gameObject;
        slider.value -= 10;
        Destroy(other);
        if (slider.value < 0) Lose();
    }

    public void Lose() {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        inGameUI.SetActive(false);
    }
}
