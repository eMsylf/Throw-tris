using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour {

    public Controls Controls;
    public BlockCreation BlockCreation;

    public int startForceMin = 10;
    public int startForceMax = 50;

    public Slider PowerSliderFill;
    
	
	private void Awake() {
        Controls = GetComponent<Controls>();
        BlockCreation = GetComponent<BlockCreation>();

        PowerSliderFill.minValue = startForceMin;
        PowerSliderFill.maxValue = startForceMax;
	}
	
	
	private void Update () {
        PowerSliderFill.value = BlockCreation.startForceMultiplier;
	}
}
