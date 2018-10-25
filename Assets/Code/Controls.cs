using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour {
    public GameObject blockLong1;
    public GameObject blockL_Normal;
    public GameObject blockL_Reverse;
    public GameObject blockPyramid;
    public GameObject blockS_Normal;
    public GameObject blockS_Reverse;
    public GameObject blockSquare;

    public List<GameObject> tetrinoList;

    public GameObject blockLong2;

    private int framesBeforeNextThrow = 0;
    private readonly int framesBeforeNextThrowMax = 60;
    private bool canThrow;

    private Vector3 spawnPosition;
    private Vector3 startForceVector;
    public int startForceX = 5;
    public int startForceY = 5;

    public int lowStartForce = 10;
    public int highStartForce = 60;

    [Range(30, 50)]
    public int startForceMultiplier = 10;

    private Quaternion spawnRotation;

    public KeyCode blockThrowKey;

    private int tetrinoListLength;

    
    private void Start() {
        startForceVector = new Vector3(startForceX, startForceY, 0f);

        spawnPosition = transform.position;
        spawnRotation = Quaternion.identity;

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
    }


    void Update() {
        if (framesBeforeNextThrow > 0) {
            framesBeforeNextThrow--;
        } else {
            //Dictionary<KeyCode, GameObject> dict = new Dictionary<KeyCode, GameObject>();

            //foreach( KeyValuePair<KeyCode, GameObject> pair in dict ) {
            //    if (Input.GetKeyDown(pair.Key)) {
            //        SpawnBlock(pair.Value);
            //    }
            //}
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                SpawnBlock(blockLong1);
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                SpawnBlock(blockL_Normal);
            } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                SpawnBlock(blockL_Reverse);
            } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                SpawnBlock(blockPyramid);
            } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
                SpawnBlock(blockS_Normal);
            } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
                SpawnBlock(blockS_Reverse);
            } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
                SpawnBlock(blockSquare);
            } else if (Input.GetKeyDown(blockThrowKey)) {
                SpawnRandomBlock();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && startForceMultiplier < highStartForce) {
            startForceMultiplier += 10;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && startForceMultiplier > lowStartForce) {
            startForceMultiplier -= 10;
        }

    }


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
