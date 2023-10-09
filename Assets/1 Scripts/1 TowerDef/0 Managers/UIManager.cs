using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {
    
    public static bool GameIsPaused = false;
    public Slider hpBar;


    public GameObject deathMenuUI;
    public GameObject winMenuUI;
    public GameObject pauseMenuUI;
    public GameObject inGameUI;

    void Start() {
        deathMenuUI.SetActive(false);
        winMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        inGameUI.SetActive(true);

        Time.timeScale = 1f;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        inGameUI.SetActive(true);
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        inGameUI.SetActive(false);
    }

    public void LoadMenu(int index) {
        Transitions.scene = index;
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        deathMenuUI.SetActive(false);
    }

}
