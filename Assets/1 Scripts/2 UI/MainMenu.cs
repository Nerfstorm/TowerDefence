using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject menupanel;
    public GameObject diffpanel;

    private void Start() {
        menupanel.SetActive(true);
        diffpanel.SetActive(false);
    }

    public void LoadScene(int index) {
        SceneManager.LoadScene(1);
        Transitions.scene = index;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
