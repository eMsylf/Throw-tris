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

    public List<GameObject> tetrinoList;

    public int framesBeforeNextThrow = 0;
    public int framesBeforeNextThrowMin = 0;
    public int framesBeforeNextThrowMax = 60;

    private readonly int startForceX = -5;
    private readonly int startForceY = 5;

    [Range(10, 50)]
    public int startForceMultiplier = 30;

    private int tetrinoListLength;

    private Vector3 spawnPosition;
    private Vector3 startForceVector;

    private Quaternion spawnRotation;


    private void Start() {
        tetrinoList = new List<GameObject> {
            blockLong1,
            blockL_Normal,
            blockL_Reverse,
            blockPyramid,
            blockS_Normal,
            blockS_Reverse,
            blockSquare
        };
        tetrinoListLength = tetrinoList.Count;

        startForceVector = new Vector3(startForceX, startForceY, 0f);

        spawnPosition = transform.position;
        spawnRotation = Quaternion.identity;
    }


    public void SpawnRandomBlock() {
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


    public void SpawnBlock(GameObject block) {
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
        framesBeforeNextThrow = framesBeforeNextThrowMin;
    }
}
