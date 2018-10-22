using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCheck : MonoBehaviour {

    private int objects = 0;
    private int objectsRequiredForClear = 10;

    public List<GameObject> blocksInLine;

	void Start () {
        blocksInLine = new List<GameObject>();
    }


    private void OnTriggerEnter(Collider other) {
        blocksInLine.Add(other.gameObject);
        objects++;
        Debug.Log("Block entering line " + gameObject.name + " " + blocksInLine.Count + " | " + objects);
        if (blocksInLine.Count >= objectsRequiredForClear) {
            ClearLine();
        }
    }


    private void OnTriggerExit(Collider other) {
        blocksInLine.Remove(other.gameObject);
        objects--;
        Debug.Log("Block exiting line " + gameObject.name + " " + blocksInLine.Count + " | " + objects);
    }


    private void ClearLine() {
        foreach (GameObject gameObject in blocksInLine) {
            gameObject.SetActive(false);
        }
        blocksInLine.Clear();
        objects = 0;
        Debug.Log("---Line cleared---");
    }
}
