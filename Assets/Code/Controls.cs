using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour {
    //public GameObject blockLong1;
    //public GameObject blockL_Normal;
    //public GameObject blockL_Reverse;
    //public GameObject blockPyramid;
    //public GameObject blockS_Normal;
    //public GameObject blockS_Reverse;
    //public GameObject blockSquare;

    public BlockCreation BlockCreation;

    public List<GameObject> tetrinoList;

    public int startForceX = 5;
    public int startForceY = 5;

    public int lowStartForce = 10;
    public int highStartForce = 60;

    [Range(30, 50)]
    public int startForceMultiplier = 10;

    public KeyCode blockThrowKey;

    private int framesBeforeNextThrow = 0;
    private int framesBeforeNextThrowMax = 60;

    private Vector3 spawnPosition;
    private Vector3 startForceVector;

    private Quaternion spawnRotation;

    private int tetrinoListLength;

    
    private void Start() {
        BlockCreation = GetComponent<BlockCreation>();

        startForceVector = new Vector3(startForceX, startForceY, 0f);

        spawnPosition = transform.position;
        spawnRotation = Quaternion.identity;

        tetrinoList = new List<GameObject> {
            BlockCreation.blockLong1,
            BlockCreation.blockL_Normal,
            BlockCreation.blockL_Reverse,
            BlockCreation.blockPyramid,
            BlockCreation.blockS_Normal,
            BlockCreation.blockS_Reverse,
            BlockCreation.blockSquare
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
                SpawnBlock(tetrinoList[0]);
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                SpawnBlock(tetrinoList[1]);
            } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                SpawnBlock(tetrinoList[2]);
            } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                SpawnBlock(tetrinoList[3]);
            } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
                SpawnBlock(tetrinoList[4]);
            } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
                SpawnBlock(tetrinoList[5]);
            } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
                SpawnBlock(tetrinoList[6]);
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
}
