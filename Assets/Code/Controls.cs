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

    public GameObject blockLong2;


    private Vector3 spawnPosition;
    private Vector3 startForceVector;
    public int startForceX = 5;
    public int startForceY = 5;
    [Range(5, 80)]
    public int startForceMultiplier ;
    private Quaternion spawnRotation;
    Rigidbody block_rb;

    public KeyCode blockThrowKey; 

    // Use this for initialization
    void Start ()
    {
//        block_rb = blockLong2.GetComponent<Rigidbody>();

        
        startForceVector = new Vector3(startForceX, startForceY, 0f);

        spawnPosition = transform.position;

        spawnRotation = Quaternion.identity;
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SpawnBlockLong1();
        }
        
        */


        


        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SpawnBlock(blockLong1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SpawnBlock(blockL_Normal);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SpawnBlock(blockL_Reverse);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            SpawnBlock(blockPyramid);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            SpawnBlock(blockS_Normal);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            SpawnBlock(blockS_Reverse);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            SpawnBlock(blockSquare);
        } 
        else if (Input.GetKeyDown(blockThrowKey)) {
            SpawnBlockLong1();
        }

    }

    
    void SpawnBlockLong1() {
        var latestBlockSpawned = Instantiate(
                blockLong2,
                spawnPosition,
                spawnRotation
                );
        latestBlockSpawned.GetComponent<Rigidbody>().AddForce(startForceVector * startForceMultiplier);
        Debug.Log("Spawn " + blockLong2.name);
    }

    void SpawnBlock(GameObject block) {
        var latestBlockSpawned = Instantiate(
                block,
                spawnPosition,
                spawnRotation
                );
        latestBlockSpawned.GetComponent<Rigidbody>().AddForce(startForceVector * startForceMultiplier);
        Debug.Log("Spawn " + latestBlockSpawned.name);
    }

    //void Test() {
    //    Physics.BoxCast();
    //    Physics.OverlapBox();
    //    Physics.ClosestPoint();
    //}

    //Rigidbody.isKinematic

}
