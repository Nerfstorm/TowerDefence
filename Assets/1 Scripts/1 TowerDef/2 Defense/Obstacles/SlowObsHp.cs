using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowObsHp : MonoBehaviour {
    
    public int maxHp;
    float hp;

    public SpriteRenderer spriterender;

    private void Start() {
        hp = maxHp;

    }

    void OnTriggerEnter2D() {
        Invoke(nameof(Damage), .2f);
    }

    void Damage() {
        hp -= 10;
        if (hp <= 0) Destroy(this.gameObject);

        spriterender.color = new Color(1, 1, 1, (hp/maxHp));
    }

}
