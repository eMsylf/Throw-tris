using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreation : MonoBehaviour {
    public GameObject blockLong1;
    public GameObject blockL_Normal;
    public GameObject blockL_Reverse;
    public GameObject blockPyramid;
    public GameObject blockS_Normal;
    public GameObject blockS_Reverse;
    public GameObject blockSquare;

    private void SpawnRandomBlock() {
        ResetFramesBeforeNextThrow();
        int randomListItem = Random.Range(0, tetrinoListLength);
        var latestBlockSpawned = Instantiate(
                tetrinoList[randomListItem],
                spawnPosition,
                spawnRotation
                );
        latestBlockSpawned.GetComponent<Rigidbody>().AddForce(startForceVector * startForceMultiplier);
        Debug.Log("Spawn " + latestBlockSpawned.name);
    }


    private void SpawnBlock(GameObject block) {
        ResetFramesBeforeNextThrow();
        var latestBlockSpawned = Instantiate(
                block,
                spawnPosition,
                spawnRotation
                );
        latestBlockSpawned.GetComponent<Rigidbody>().AddForce(startForceVector * startForceMultiplier);
        Debug.Log("Spawn " + latestBlockSpawned.name);
    }


    private void ResetFramesBeforeNextThrow() {
        framesBeforeNextThrow = framesBeforeNextThrowMax;
    }
}
