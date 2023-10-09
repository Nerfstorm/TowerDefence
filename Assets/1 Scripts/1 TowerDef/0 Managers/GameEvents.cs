using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

    public static GameEvents damage;

    private void Awake() {
        damage = this;
    }

    public event Action onGetToWall;
    public void GetToWall() {
        if (onGetToWall != null) {
            onGetToWall();
        }
    }
}
