using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopObsHp : MonoBehaviour {

    public int maxHp;
    float hp;

    public SpriteRenderer spriterender;
    //int AtttackerNr;

    private void Start() {
        hp = maxHp;

        //spriterender = gameObject.GetComponentInParent<SpriteRenderer>();
    }

    void OnTriggerEnter2D() {
        InvokeRepeating(nameof(Damage), .5f, .5f);
    }

    void Damage() {
        hp -= 5;
        if (hp <= 0) Destroy(this.gameObject); 

    spriterender.color = new Color(1, 1, 1, hp/maxHp);
    }

}
