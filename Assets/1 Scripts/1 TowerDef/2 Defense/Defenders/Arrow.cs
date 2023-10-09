using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public int damage = 10;
    public float smaller;

    private void Start() {
        InvokeRepeating(nameof(Smaller), smaller, smaller);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        GameObject other = collider.gameObject;
        if (other.layer == 7) Destroy(gameObject);
        else if (other.layer == 17) Destroy(gameObject);
    }
    void Smaller() {
        transform.localScale -= new Vector3(5, 5, 0);
        if (transform.localScale.x < 5) Destroy(this.gameObject);
    }
}
