using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transitions : MonoBehaviour {
    public static int scene;


    public Sprite[] images;

    public Image Background;

    void Start() {
        int num = UnityEngine.Random.Range(0, images.Length-1);
        Background.sprite = images[num];
    }
}
