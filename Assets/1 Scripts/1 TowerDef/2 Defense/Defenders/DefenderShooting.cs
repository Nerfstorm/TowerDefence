using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooting : MonoBehaviour {

    //pt rotire

    public Transform transf;
    public Camera cam;
    public float smooth = 5f;
    Vector2 mousePos;

    // pt shooting

    public Transform firepoint;
    public GameObject ArrowPrefab;

    public float ArrowForce = 20f;
    public float ReloadTime = 2f;
    float TimeLeftReload;

    void Start() {
        TimeLeftReload = ReloadTime;
    }

    void Update() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); // tre sa fac un pic random

        if (TimeLeftReload <= 0) {

            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > Screen.height * 0.30) { // ca sa nu traga in UI, tre sa am variabilele intr-un data ca lumea, dar saracie
                Shoot();
                TimeLeftReload = ReloadTime;
            }

        } else {
            TimeLeftReload -= Time.deltaTime;
        }
    }

    //tat asta tre facut de la 0, vai de pula ta :)

    void FixedUpdate() {
        Vector2 lookDir = mousePos - new Vector2(transf.position.x, transf.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transf.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    void Shoot() {
        GameObject arrow = Instantiate(ArrowPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * ArrowForce, ForceMode2D.Impulse);
    }

}
