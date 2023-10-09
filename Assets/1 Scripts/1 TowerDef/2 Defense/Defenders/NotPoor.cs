using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotPoor : MonoBehaviour {

    Transform drag;
    Transform dragNot;

    public int price;

    private void Start() {
        drag = gameObject.transform.Find("Dragger");
        dragNot = gameObject.transform.Find("Poor");
    }

    void FixedUpdate() {
        if (CoinCount.coinamount >= price) {
            drag.gameObject.SetActive(true);
        } else drag.gameObject.SetActive(false);
    }
}
