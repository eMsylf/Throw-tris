using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCheck : MonoBehaviour {

    private int objects = 0;

    private List<GameObject> blocksInLine;

	// Use this for initialization
	void Start () {

        blocksInLine = new List<GameObject>();
}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter(Collider other) {
        blocksInLine.Add(other.gameObject);
        objects++;
        Debug.Log("Block entering line " + gameObject.name + " " + blocksInLine.Count + " | " + objects);
        if (objects >= 15) {
            foreach (GameObject gameObject in blocksInLine) {
                gameObject.SetActive(false);
            }
            blocksInLine.Clear();
            objects = 0;
            Debug.Log("---Line cleared---");
        }
    }

    private void OnTriggerExit(Collider other) {
        blocksInLine.Remove(other.gameObject);
        objects--;
        Debug.Log("Block exiting line " + gameObject.name + " " + blocksInLine.Count + " | " + objects);
    }

    private void ClearLine() {
        
    }
}
