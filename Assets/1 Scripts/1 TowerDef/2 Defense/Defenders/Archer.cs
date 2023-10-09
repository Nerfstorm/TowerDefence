using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Archer : MonoBehaviour {

    //pt rotire

    public Transform transf;
    public Camera cam;
    public float smooth = 5f;

    // pt shooting

    public Transform firepoint;
    public GameObject ArrowPrefab;

    public float ArrowForce = 20f;
    public float ReloadTime = 2;
    float TimeLeftReloading;

    //AI
    public Collider2D MaxRange;

    //Transform Target;
    List<GameObject> EnemyList;
    GameObject CurrentTarget;
    bool isShooting;

    void Start() {
        isShooting = false;
        EnemyList = new List<GameObject>();
        TimeLeftReloading = ReloadTime;
    }

    void Update() {

        if (isShooting == false) {
            if (EnemyList.Any()) {
                EnemyList.RemoveAll(s => s == null);
                if (EnemyList.Any()) {
                    CurrentTarget = ChooseTarget(); // surprinzator, merge
                    isShooting = true;
                    if (TimeLeftReloading <= 0) TimeLeftReloading = ReloadTime;
                }
            }
        } else {
            if (TimeLeftReloading <= 0) {
                Shoot();
                TimeLeftReloading = ReloadTime;
            } else TimeLeftReloading -= Time.deltaTime; //merge reload-u
        }
    }

    private void FixedUpdate() {
        if (isShooting == true)
            if (CurrentTarget) {
                transf.up = CurrentTarget.transform.position - transf.position;//+ new Vector3(0,0,-90);
            } else { isShooting = false; EnemyList.Remove(CurrentTarget); }
    }


    void OnTriggerEnter2D(Collider2D collider) {
        GameObject other = collider.gameObject;
        if (other.layer == 7) EnemyList.Add(collider.gameObject); // merge
    }

    void Shoot() {
        GameObject arrow = Instantiate(ArrowPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * ArrowForce, ForceMode2D.Impulse);
    }

    GameObject ChooseTarget() {
        GameObject Mini = EnemyList[0];
        foreach (GameObject e in EnemyList) {
            if (!e.GetComponentInChildren<EnemyAI>()) EnemyList.Remove(e);
            else if (e.GetComponentInChildren<EnemyAI>().GetDistanceToTarget() < Mini.GetComponentInChildren<EnemyAI>().GetDistanceToTarget()) Mini = e;
        }
        return Mini;
    }
}
