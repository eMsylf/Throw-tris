using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrinoChild : MonoBehaviour {
    Rigidbody child_rb;
    

    private void Start () {
        child_rb = GetComponent<Rigidbody>();
	}
	
	
	private void Update () {
        if (child_rb.velocity.y > 100.0f) {
            child_rb.constraints = RigidbodyConstraints.FreezeAll;
            gameObject.SetActive(false);
        }
	}
}
