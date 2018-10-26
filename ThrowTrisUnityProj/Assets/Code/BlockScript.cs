using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    private readonly float outOfBoundsDistance = 50f;

    private Vector3 spawnPos;
    private Rigidbody rb;

    private int frameCount;
    private readonly int framesBeforeDetach = 2;

    private bool childrenGotRigidbodies = false;


    private void Start() {
        spawnPos = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
    }


    private void Update() {
        frameCount++;
        if (frameCount == framesBeforeDetach) {
            AddRigidbodiesToChildren();
            DetachChildrenFromTetrino();
        }
        
        if (Vector3.Distance(gameObject.transform.position, spawnPos) > outOfBoundsDistance) {
            Destroy(gameObject);
            Debug.Log(gameObject.name + "destroyed because out of bounds");
        }
    }


    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision between " + name + " and " + collision.gameObject.name);
        if (!childrenGotRigidbodies) {
            AddRigidbodiesToChildren();
        }
    }


    private void DetachChildrenFromTetrino() {
        gameObject.transform.DetachChildren();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        gameObject.SetActive(false);
    }


    private void AddRigidbodiesToChildren() {
        foreach (Transform child in transform) {
            Rigidbody child_rb = child.gameObject.AddComponent<Rigidbody>();
            child_rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            child_rb.velocity = rb.velocity;
        }
        childrenGotRigidbodies = true;
    }
}
