using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour {

    int coinstart;
    int coinpersecond;
    public static int coinamount;


    public Text goldcount;



    private void Start() {
        coinstart = LevelData.Startcoin;
        coinpersecond = LevelData.PerSecondcoin;

        coinamount = coinstart;
        InvokeRepeating(nameof(AddCoin), 1f, 1f);
    }

    private void FixedUpdate() {
        goldcount.text = coinamount.ToString();
    }

    void AddCoin() {
        coinamount += coinpersecond;
    }

    public static void AddCoinS(int amount) {
        coinamount += amount;
    }

    public static void RemoveCoinS(int amount) {
        coinamount -= amount;
    }

}
