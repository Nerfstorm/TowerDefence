using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CheckDrop : MonoBehaviour {

    public GameObject Obstacle;

    public int maxPenalty;

    void Start() {

        GraphNode node = AstarPath.active.GetNearest(transform.position).node;
        if (node.Penalty > maxPenalty) Destroy(this.gameObject);

        Invoke(nameof(Spawn), 0.1f);
    }


    void OnTriggerEnter2D(Collider2D collider) {
        if (!collider.CompareTag("Untagged") && !collider.CompareTag("Projectile")) Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (!collider.CompareTag("Untagged") && !collider.CompareTag("Projectile")) Destroy(this.gameObject);
    }

    void Spawn() {
        Instantiate(Obstacle, this.transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(this.gameObject);
    }
}
