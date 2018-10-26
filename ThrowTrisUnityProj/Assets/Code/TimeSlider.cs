using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour {

    public BlockCreation BlockCreation;

    public Slider TimeSliderFill;

	
	private void Awake () {
        BlockCreation = GetComponent<BlockCreation>();

        TimeSliderFill.maxValue = BlockCreation.framesBeforeNextThrowMax;
	}
	
	
	private void Update () {
        TimeSliderFill.value = BlockCreation.framesBeforeNextThrow;
	}
}
