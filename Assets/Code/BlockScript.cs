using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //void Update () {

    //       if (Vector3.Distance(gameObject.transform.position, spawnPos) > 100f) {
    //           Destroy(gameObject);
    //           Debug.Log(gameObject.name + "destroyed because out of bounds");
    //       }
    //   }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision between " + name + " and " + collision.gameObject.name);


        rb.constraints = RigidbodyConstraints.FreezeAll;


        gameObject.transform.parent = null;

        gameObject.SetActive(false);
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
