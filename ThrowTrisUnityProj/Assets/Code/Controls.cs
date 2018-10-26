using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public BlockCreation BlockCreation;
    public PowerSlider PowerSlider;

    public KeyCode blockThrowKey;
    

    private void Awake() {
        PowerSlider = GetComponent<PowerSlider>();
        BlockCreation = GetComponent<BlockCreation>();
    }


    private void Update() {
        if (BlockCreation.framesBeforeNextThrow < BlockCreation.framesBeforeNextThrowMax) {
            BlockCreation.framesBeforeNextThrow++;
        } else {
            //Dictionary<KeyCode, GameObject> dict = new Dictionary<KeyCode, GameObject>();

            //foreach( KeyValuePair<KeyCode, GameObject> pair in dict ) {
            //    if (Input.GetKeyDown(pair.Key)) {
            //        SpawnBlock(pair.Value);
            //    }
            //}
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                BlockCreation.SpawnBlock(BlockCreation.tetrinoList[0]);
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                BlockCreation.SpawnBlock(BlockCreation.tetrinoList[1]);
            } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                BlockCreation.SpawnBlock(BlockCreation.tetrinoList[2]);
            } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                BlockCreation.SpawnBlock(BlockCreation.tetrinoList[3]);
            } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
                BlockCreation.SpawnBlock(BlockCreation.tetrinoList[4]);
            } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
                BlockCreation.SpawnBlock(BlockCreation.tetrinoList[5]);
            } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
                BlockCreation.SpawnBlock(BlockCreation.tetrinoList[6]);
            } else if (Input.GetKeyDown(blockThrowKey)) {
                BlockCreation.SpawnRandomBlock();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && BlockCreation.startForceMultiplier < PowerSlider.startForceMax) {
            BlockCreation.startForceMultiplier += 10;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && BlockCreation.startForceMultiplier > PowerSlider.startForceMin) {
            BlockCreation.startForceMultiplier -= 10;
        }
    }
}
