using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    private float outOfBoundsDistance = 50f;

    private Vector3 spawnPos;
    private Rigidbody rb;


    private int frameCount;
    private int framesBeforeDetach = 15;


    private bool childrenGotRigidbodies = false;
    private bool childrenDetached = false;

    // Use this for initialization
    void Start() {

        foreach (Transform child in transform) {
            child.GetComponent<Rigidbody>();
        }

        spawnPos = gameObject.transform.position;

        rb = GetComponent<Rigidbody>();

        //StartCoroutine("WaitAndEnableRigidbodies");
    }

    //Update is called once per frame
    void Update() {
        frameCount++;
        if (frameCount == framesBeforeDetach) {

            AddRigidbodiesToChildren();
        }

        if (childrenGotRigidbodies && !childrenDetached) {
            DetachChildren();
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

    private void DetachChildren() {

        gameObject.transform.DetachChildren();

        rb.constraints = RigidbodyConstraints.FreezeAll;

        gameObject.SetActive(false);

        childrenDetached = true;
    }

    private void AddRigidbodiesToChildren() {

        foreach (Transform child in transform) {
            Rigidbody child_rb = child.gameObject.AddComponent<Rigidbody>();
            child_rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            child_rb.velocity = rb.velocity;
        }
        childrenGotRigidbodies = true;
    }




    //transform.GetComponentInParent<BlockScript>().transform.DetachChildren();

    //transform.DetachChildren();

    //for (int i = 0; i < 3; i++) {
    //    Transform child = this.gameObject.transform.GetChild(i);
    //}


    //if (!name.Contains("Cube")){
    //    rb.velocity = new Vector3(0,0,0);
    //    rb.isKinematic = true;
    //}

    /*
    if (GetComponentInParent<BlockScript>() != null) {
        GetComponent<BoxCollider>().enabled = false;
    }
    else {
        GetComponent<BoxCollider>().enabled = true;
    }
    */

}
