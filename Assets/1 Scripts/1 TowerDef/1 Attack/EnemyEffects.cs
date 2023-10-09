using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffects : MonoBehaviour {

    public int bounty;
    public int healthMax;
    int health;
    public GameObject HpBar;

    GameObject Enemy;
    public Animator animator;

    EnemyAI enemyAi;

    private void Start() {

        healthMax = LevelData.EnemyHealthMax;

        health = healthMax;

        Enemy = this.gameObject;

        enemyAi = gameObject.GetComponentInParent(typeof(EnemyAI)) as EnemyAI;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        GameObject other = collider.gameObject;

        switch (other.tag) {
            case "Slower": { enemyAi.speed /= 2; animator.speed = enemyAi.speed/enemyAi.MaxSpeed; }
                break;
            case "Wood":
                enemyAi.speed = 0;
                break;
            case "Projectile":
                Arrow arrow = other.GetComponent<Arrow>();
                EnemyDamaged(arrow.damage);
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        GameObject other = collider.gameObject;

        switch (other.tag) {
            case "Slower": { enemyAi.speed = enemyAi.MaxSpeed; animator.speed = enemyAi.MaxSpeed; }
                break;
            case "Wood":
                enemyAi.speed = enemyAi.MaxSpeed;
                break;
            default:
                break;
        }
    }

        void EnemyDamaged(int damage) {
            health -= damage;
        if (health >= 0) HpBar.transform.localScale = new Vector3((float)health / healthMax, 1);
        else {CoinCount.AddCoinS(bounty); Destroy(gameObject); };
        }

}

