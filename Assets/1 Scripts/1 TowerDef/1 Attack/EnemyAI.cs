using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour {

    public Transform target;

    public int MaxSpeed;
    public float speed;
    public float nextWaypointDistance = 10f;
    public float update = .5f;

    Path path;
    int currentWaypoint = 0;

    Seeker seeker;
    Transform transf;


    public Animator animator;


    void Start() {

        MaxSpeed = LevelData.EnemySpeed;

        seeker = GetComponent<Seeker>();
        transf = GetComponent<Transform>();

        InvokeRepeating(nameof(UpdatePath), 0f, update);

        speed = MaxSpeed;
    }

    private void Update() {

        animator.SetFloat("Speed", speed);

    }

    void UpdatePath() {
        if (seeker.IsDone()) {
            seeker.StartPath(transf.position, target.position, OnPathComplete);
        }
    }

    void FixedUpdate() {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count) return;

        Vector2 direction = ((Vector3)path.vectorPath[currentWaypoint] - transf.position).normalized;
        Vector2 force = speed * Time.deltaTime * direction;

        transf.Translate(force);

        float distance = Vector2.Distance(transf.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }

    }

    void OnPathComplete(Path p) {
        if(!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    //added

    public float GetDistanceToTarget() {
        List<Vector3> vPath = path.vectorPath;
        float totalDistance = 0;

        Vector3 current = transform.position;

        //Iterate through vPath and find the distance between the nodes
        for (int i = currentWaypoint; i < vPath.Count; i++) {
            totalDistance += (vPath[i] - current).magnitude;
            current = vPath[i];
        }

        totalDistance += (target.position - current).magnitude;

        return totalDistance;
    }



}
